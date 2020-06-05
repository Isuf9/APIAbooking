using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAbooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIAbooking.Controllers
{
    public class OwnerController : Controller
    {
        private readonly APIAbookingContext _dbContext;

        public OwnerController(APIAbookingContext db)
        {
            _dbContext = db;
        }
        public IActionResult Dashboard(Room _room) => View();

        public IActionResult Login() => View(nameof(Login));

        [HttpPost]
        public IActionResult Login(RoomOwner _owner)
        {
            if (ModelState.IsValid)
            {
                if (_owner.OwnerId == 0)
                {
                    NotFound();
                }
            }

            var _EmailOwner = _dbContext.RoomOwners.Where(x => x.Email == _owner.Email).FirstOrDefault();

            var _PasswordOwner = _dbContext.RoomOwners.Where(x => x.Email == _owner.Password).FirstOrDefault();

            if(_EmailOwner == null && _PasswordOwner == null)
            {
                return View(nameof(Login));
            }
            else
            {
                return RedirectToAction(nameof(Dashboard), _owner.Email);
            }
            return View(_owner);
        }

        public IActionResult Create() => View(nameof(Create));



    }
}