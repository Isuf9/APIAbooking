﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIAbooking.Models;
using System.Data.Entity.Infrastructure;
using APIAbooking.Services;
using System.Text;
using Microsoft.Extensions.Localization;
using ReflectionIT.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Collections;

namespace APIAbooking.Controllers
{
  
    public class ClientsController : Controller
    {
        #region Properties
        private readonly APIAbookingContext _dbContext;
        private readonly IClientService _clientService;
        private readonly IStringLocalizer<ClientsController> _localizer;
        public ClientsController(APIAbookingContext db, IClientService client, IStringLocalizer<ClientsController> localizer)
        {
            _dbContext = db;
            _clientService = client;
            _localizer = localizer;
        }
        #endregion


        public async Task<IActionResult> Home(int page=1)
        {
            var item = _dbContext.Rooms.AsNoTracking().OrderBy(x => x.RoomId);
            
            var model = await PagingList<Room>.CreateAsync(item, 3, page);
            return View(model);
            //if(searchBy == "Contry")
            //{
            //    return View(_dbContext.Rooms.Where(x => x.Country == search || search == null)
            //        .ToList()
            //        .ToPagedList(page ?? 1, 3));
            //}
            //else
            //{
            //    return View(_dbContext.Rooms.Where(x => x.Describe.StartsWith(search) || search == null)
            //        .ToList()
            //        .ToPagedList(page ?? 1, 3));
            //}
        }

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
            return View(_clientService.GetById(id));
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
            return View(_dbContext.Clients.Where(x =>x.Email == client.Email));
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
        public async Task<IActionResult> Login(Client client)
        {
            var result = _clientService.Login(client.Email, client.Password);
           
            if(result == null)
            {
                ModelState.AddModelError("Password", _localizer["Email or password are wrong, enter again"].ToString());
                return View(result);
            }
            else
            {
                return RedirectToAction("HomePage", result);
            }
            return View(result);
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
        //[HttpPost]
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
                        
                    }
                    else
                    {
                        ModelState.AddModelError("Email", _localizer["Now this email is used, please enter a new!"].ToString());
                        return View(client);
                    }
                }


                return RedirectToAction("HomePage", client);
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
        //public async Task<IActionResult> Edit(string id, [Bind("ClientId,Name,Lastname,Email,Password,ProfilePicture,TypeOfUser")] Client client)
        //{
        //    if(client.ClientId == null)
        //    {
        //        NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _dbContext.Update(client);
        //            await _dbContext.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (client.ClientId == null)
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Login));
        //    }
        //    return View(client);
        //}

        //[Route("clients/index")]
        public IActionResult Index() => View(nameof(Index));
        #endregion
    }
}


