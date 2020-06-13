using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIAbooking.Models;
using System.Data.Entity.Infrastructure;
using System;
using APIAbooking.Infrastructure.RandomClass;

namespace APIAbooking.Controllers
{
    public class ClientsController : Controller
    {
        #region Properties
        private readonly APIAbookingContext _dbContext;
        //private Random _random;
        public ClientsController(APIAbookingContext db)
        {
            _dbContext = db;
        }
        #endregion

        #region Constructor
        [Route("api/clients/index/id")]
        public async Task<IActionResult> Index(string? id)
        {
            if (id == null)
            {
                NotFound();
            }
            return View(_dbContext.Clients.Where(i => i.ClientId == id));
        }
        #endregion

        #region ActionMethods
        /// <summary>
        /// Ti kthen te dhenat personale te userit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> PersonalInfo(string? id)
        {
            if (id == null)
            {
                NotFound();
            }
            return View(_dbContext.Clients.Where(i => i.ClientId == id));
        }

        /// <summary>
        /// Home page e userit qe i shfaqen te dhenat e postimeve
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpGet]
        //[Route("clients/homepage/ClientId")]
        public async Task<IActionResult> HomePage(Client client)
        {
            if (client.Email == null)
            {
                NotFound();
            }
            return View(_dbContext.Clients.Where(i => i.Email == client.Email));
        }

        /// <summary>
        /// Kthen view per login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login() => View(nameof(Login));
        
        /// <summary>
        /// I validon te dhenat e userit pasi ti jep te dhenat e tij per login
        /// </summary>
        /// <param name="_client"></param>
        /// <returns></returns>
        [HttpPost]
       // [Route("clients/login/clientId")]
        public async Task<IActionResult> Login(Client _client)
        {
            
             var _EmailClient =  _dbContext.Clients
                .Where(c => c.Email == _client.Email)
                .FirstOrDefault(); //krahasimi i te dhenave prej textfield edhe databazes

            var _PasswordClient = _dbContext.Clients
                .Where(c => c.Password == _client.Password)
                .FirstOrDefault();

            
            if ( _EmailClient == null && _PasswordClient == null )
            {
                ViewBag.Message = "Your email or password is wrong!";
                return View();
            }
            else if( _EmailClient != null && _PasswordClient != null)
            {   
                ViewBag.Message = "You email and password are correct!";
                return RedirectToAction("HomePage", _client);
            }
            
            return View(_client);
        }

        /// <summary>
        /// E kthen view e create per tu regjistruar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create() => View(nameof(Create));

        /// <summary>
        /// E shton nje user ne app pasi useri ti jep te dhenat e veta personale
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult Create(Client client)
        {
           
            if (ModelState.IsValid)
            {
                if (client.ClientId != null)
                {
                    _dbContext.Clients.Add(client);
                }
               
                _dbContext.SaveChanges();
                return RedirectToAction("HomePage", client);
            }
            return View(client);
        }
        /// <summary>
        /// E kthen view edit me te dhena te mbushura te userit te sakt 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            
            if(id == null)
            {
                NotFound("404 error");
            }

            var client = _dbContext.Clients.Find(id);

            if (client == null)
            {
                NotFound("404 error");
            }
            return View(client);
        }

        /// <summary>
        /// I ndryshon te dhenat e useri pasi aij te klikon buttonin update...
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("ClientId,Name,Lastname,Email,Password,ProfilePicture,TypeOfUser")] Client client)
        {
            if(client.ClientId == null)
            {
                NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(client);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (client.ClientId == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Login));
            }
            return View(client);
        }

        //[Route("clients/index")]
        public IActionResult Index() => View(nameof(Index));
        #endregion
    }
}


