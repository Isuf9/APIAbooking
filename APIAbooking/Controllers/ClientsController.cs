using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIAbooking.Models;
using APIAbooking.Services;
using System.Text;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;
using APIAbooking.Services.RoomService;
using System;
using ReflectionIT.Mvc.Paging;

namespace APIAbooking.Controllers
{
  
    public class ClientsController : Controller
    {
        #region Properties
        private readonly APIAbookingContext _dbContext;
        private readonly IClientService _clientService;
        private readonly IService  _iService;
        private readonly IStringLocalizer<ClientsController> _localizer;
        
        #endregion


        #region Constructor
        public ClientsController
                (
                APIAbookingContext db,
                IClientService client,
                IService service,
                IStringLocalizer<ClientsController> localizer
                )
                    {
                        _dbContext = db;
                        _clientService = client;
                        _iService = service;
                        _localizer = localizer;
                    }
        #endregion

        #region ActionMethods


        /// <summary>
        /// Home page e userit qe i shfaqen te dhenat e postimeve
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        //
        //[Route("clients/homepage/ClientId")]
        [HttpGet]
        public IActionResult Home()
        {
            //string country, DateTime checkin, DateTime checkout, int maxGuests
           
            return View();
        }
        [HttpPost]
        public IActionResult Home(Room _room)
        {
            //string country, DateTime checkin, DateTime checkout, int maxGuests
            var _getAllRooms = _dbContext.Rooms
                .OrderBy(x => x.Price)
                //.ThenByDescending(x => x.Checkin)
                //.ThenByDescending(x => x.Checkout)
                //.ThenByDescending(x => x.MaxGuest)
                .Where(x=> x.Country == _room.Country
                && x.Checkin == _room.Checkin
                && x.Checkout == _room.Checkout
                && x.MaxGuest == _room.MaxGuest)
                .Select(x=> new Room {
                NameOfRoom = x.NameOfRoom,
                Country = x.Country,
                City = x.City,
                Describe = x.Describe
                })
                .ToList();
            var result = _getAllRooms;
            //return View(_getAllRooms);
            return RedirectToAction(nameof(Index), _getAllRooms);
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            
            ViewBag.currentUser = HttpContext.Session.GetString("Name");
            ViewBag.Id = HttpContext.Session.GetString("Id");
            var item =  _clientService.GetAllPost();
            //var model = await PagingList.CreateAsync(item, 4, page);

            return  View(item);
        }

        public IActionResult Detalist(string id)
        {
            if(id == null)
            {
                return View();
            }
            else
            {
                return View(_dbContext.Rooms.Where(x =>x.RoomId == id));
            }
        }
        
        
        /// <summary>
        /// Ti kthen te dhenat personale te userit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> PersonalInfo(string id)
        {
            if (id == null)
            {
                NotFound();
            }
            return View(_clientService.GetById(id));
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
        public IActionResult Login(Client client)
        {
            client.Password = _clientService.EncryptPassword(Encoding.UTF8, client.Password);
            var result =  _clientService.Login(client.Email, client.Password);

            
            if(result == null)
            {
                ModelState.AddModelError("Password", _localizer["Email or password are wrong, enter again"].ToString());
                return View(result);
            }
            else
            {
                HttpContext.Session.GetString("Name");
                HttpContext.Session.GetString("Id");
                return RedirectToAction(nameof(Index));
                
            }
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
        /// 


        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = _clientService.GenerateIdRandom(client.ClientId);
                if (client.ClientId != null)
                {
                    var result = _clientService.IfEmailExist(client.Email);
                    //client.IsExist = result;
                    if (result == false)
                    {

                        client.Password = _clientService.EncryptPassword(Encoding.UTF8, client.Password);
                        _clientService.Create(client);
                        HttpContext.Session.SetString("Name", client.Name + " " + client.Lastname);
                        HttpContext.Session.SetString("Id", client.ClientId);
                        return RedirectToAction(nameof(Index), "Clients");

                    }
                    else
                    {
                        ModelState.AddModelError("Email", _localizer["Now this email is used, please enter a new!"].ToString());
                        return View(client);
                    }
                }
                return RedirectToAction("Index", client);
            }
            return View(client);
        }


        /// <summary>
        /// E kthen view edit me te dhena te mbushura te userit te sakt 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T'kthen te faqja kryesore </returns> 
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if(id == null)
            {
                NotFound("404 error");
            }
            
            var client = _clientService.Edit(id);

            if (client == null)
            {
                NotFound("404 error");
            }
            return View(client);
        }

        #endregion
    }
}


