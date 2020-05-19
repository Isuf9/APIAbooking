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

        public ClientsController(IClientRepository context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(_context.GetClients);
        }

       
    }
}
