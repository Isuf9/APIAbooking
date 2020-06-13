using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAbooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAbooking.Controllers
{
    public class OwnerController : Controller
    {
        private readonly APIAbookingContext _dbContext;

        public OwnerController(APIAbookingContext db)
        {
            _dbContext = db;
        }
        public IActionResult Dashboard(RoomOwner owner)
        {
            if(owner.Email == null)
            {
                NotFound();
            }
            return View(_dbContext.RoomOwners.Where(x => x.Email == owner.Email));
        }

        //public IActionResult CreateRoom(Room room) => View();

        public IActionResult Login() => View(nameof(Login));

        [HttpPost]
        public IActionResult Login(RoomOwner _owner)
        {
            if (ModelState.IsValid)
            {
                if (_owner.OwnerId == null)
                {
                    NotFound();
                }
            }

            var _EmailOwner = _dbContext.RoomOwners.Where(x => x.Email == _owner.Email).FirstOrDefault();

            var _PasswordOwner = _dbContext.RoomOwners.Where(x => x.Email == _owner.Password).FirstOrDefault();

            if (_EmailOwner == null && _PasswordOwner == null)
            {
                return View(nameof(Login));
            }
            else
            {
                return RedirectToAction("Dashboard",_owner);
            }
            return View(_owner);
        }

        public IActionResult Create() => View(nameof(Create));

        [HttpPost]
        public IActionResult Create(RoomOwner owner)
        {

            if (ModelState.IsValid)
            {
                if (owner.OwnerId != null)
                {
                    _dbContext.RoomOwners.Add(owner);
                }

                _dbContext.SaveChanges();
                return RedirectToAction("Dashboard", owner);
            }
            return View(owner);
        }

        public IActionResult CreatePost() => View(nameof(CreatePost));

        [HttpPost]
        public IActionResult CreatePost(Room room)
        {

            if (ModelState.IsValid)
            {
                if (room.RoomId != null)
                {
                    _dbContext.Rooms.Add(room);
                }

                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Dashboard));
            }
            return View(room);
        }
        /// <summary>
        /// E kthen view edit me te dhena te mbushura te userit te sakt 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == 0)
            {
                NotFound("404 error");
            }

            var owner = _dbContext.RoomOwners.Find(id);

            if (owner == null)
            {
                NotFound("404 error");
            }
            return View(owner);
        }

        /// <summary>
        /// I ndryshon te dhenat e useri pasi aij te klikon buttonin update...
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,Name,Lastname,Email,Password,ProfilePicture,TypeOfUser")] RoomOwner owner)
        {
            if (owner.OwnerId == null)
            {
                NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(owner);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (owner.OwnerId == null)
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
            return View(owner);
        }

    }
}