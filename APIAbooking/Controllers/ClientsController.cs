using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIAbooking.Models;

namespace APIAbooking.Controllers
{
    public class ClientsController : Controller
    {
        private IClientRepository _context;
        private APIAbookingContext _dbContext;
        [BindProperty]
        public Client _client { get; set; }
        public ClientsController(IClientRepository context, APIAbookingContext db)
        {
            _context = context;
            _dbContext = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(_client);
        }
        [HttpPost]
        public async Task<IActionResult> Login(Client _client)
        {
            
             var _EmailClient =  _context.GetClients
                .Where(c => c.Email == _client.Email)
                .FirstOrDefault(); //krahasimi i te dhenave prej textfield edhe databazes

            var _PasswordClient = _context.GetClients
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(int? id)
        {

            if (ModelState.IsValid)
            {
                if (id != 0)
                {
                    _dbContext.Clients.Add(_client);
                }
               
                _dbContext.SaveChanges();
                return RedirectToAction("HomePage");
            }
            return View(_client);

        }
      

        [HttpGet]
        public IActionResult HomePage(Client client)
        {
            return View(_context.GetClients.Where(x => x.ClientId == client.ClientId));
        }

               
        // GET: Profi of user
        public async Task<IActionResult> Index()
        {
           
            return View(_context.GetClients);
        }


    }
}
