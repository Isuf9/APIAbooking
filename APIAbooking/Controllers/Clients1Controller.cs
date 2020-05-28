using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIAbooking.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace APIAbooking.Controllers
{
    public class Clients1Controller : Controller
    {
        private readonly APIAbookingContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
       // private readonly UserManager<APIAbookingContext> _userManager;
       // private readonly SignInManager<IdentityUser> _siginManager;
        public Clients1Controller(APIAbookingContext context, IHttpContextAccessor httpcontext)
        {
            _context = context;
            _httpContextAccessor = httpcontext;
        }
        //clients1/index/1
        public async Task<IActionResult> Index(int? id)
        {
            if(id == 0)
            {
                NotFound();
            }

            return View(_context.Clients.Where(i =>i.ClientId == id));
        }

        // GET: Clients1
        [HttpGet]
        public async Task<IActionResult> HomePage(Client client)
        {
           
            if (client == null)
            {
                NotFound();
            }

            return View(_context.Clients.Where(i => i.Email == client.Email));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Client client)
        {

            Client _EmailClient = _context.Clients
               .Where(c => c.Email == client.Email)
               .FirstOrDefault(); //krahasimi i te dhenave prej textfield edhe databazes

            Client _PasswordClient = _context.Clients
                .Where(c => c.Password == client.Password)
                .FirstOrDefault();
            

           

            if (_EmailClient == null && _PasswordClient == null)
            {
                ViewBag.Message = "Your email or password is wrong!";
                return View();
            }
            else if (_EmailClient != null && _PasswordClient != null)
            {
                ViewBag.Message = "You email and password are correct!";
                return RedirectToAction("HomePage", client);
            }

            return View(client);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ClientId,Name,Lastname,Email,Password,ProfilePicture,TypeOfUser")] Client client)
        {

            if (ModelState.IsValid)
            {
                if (client.ClientId != 0)
                {
                    _context.Clients.Add(client);
                }

                _context.SaveChanges();
                return RedirectToAction("Index", client.ClientId);
            }
            return View(client);

        }
     

        // GET: Clients1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients1/Create


        // GET: Clients1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,Name,Lastname,Email,Password,ProfilePicture,TypeOfUser")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
