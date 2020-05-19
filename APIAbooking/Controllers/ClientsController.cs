using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIAbooking.Models;

namespace APIAbooking.Controllers
{
    public class ClientsController : Controller
    {
        private IClientRepository _context;
        private APIAbookingContext _dbContext;
        //public Client _client { get; set; }
        public ClientsController(IClientRepository context, APIAbookingContext db) 
        {
           _context = context;
            _dbContext = db;
        }

        public async Task<IActionResult> Login(Client client)
        {
            var _clientDb = _context.GetClients
                .Where(c => c.Email == client.Email ||
                c.Name == client.Name &&
                c.Password == client.Password).
                FirstOrDefault(); //krahasimi i te dhenave prej textfield edhe databazes

            if (_clientDb == null)
            {
                ViewBag.Message = "You email and password are wrong!";
                return View();
            }
            else
            {
                ViewBag.Message = "You email and password are correct!";
                return RedirectToAction("HomePage");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(Client client)
        {

            if (ModelState.IsValid)
            {
                if (client.ClientId != 0)
                {
                    _dbContext.Clients.Add(client);
                }
               
                _dbContext.SaveChanges();
                return RedirectToAction("HomePage");
            }
            return View(client);

        }

        public IActionResult HomePage()
        {
            return View(_context.GetClients);
        }
        // GET: Profi of user
        public async Task<IActionResult> Index()
        {
            return View(_context.GetClients);
        }


    }
}
