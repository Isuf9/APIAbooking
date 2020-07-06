using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAbooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using ReflectionIT.Mvc.Paging;

namespace APIAbooking.Controllers
{
    public class RoomController : Controller
    {
        private APIAbookingContext _dbContext;
        public RoomController(APIAbookingContext db)
        {
            _dbContext = db;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var item = _dbContext.Rooms.AsNoTracking().OrderBy(x => x.Price);
            var model = await PagingList<Room>.CreateAsync(item, 4, page);
            return View(model);
        }

        public IActionResult Create() => View(nameof(Create));

        [HttpPost]
        public IActionResult Create(string? id, Room room)
        {
            if(room.RoomId == null)
            {
                NotFound();
            }
            else
            {
                room.OwnerIdFk = id;
                _dbContext.Rooms.Add(room);
                _dbContext.SaveChanges();

                return RedirectToAction("Dashboard", "RoomOwner");
            }
            return View(room);
        }

        public IActionResult GetAllPost(string owner_id) => View(_dbContext.Rooms.Where(x => x.OwnerIdFk == owner_id));



        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {

            if (id == null)
            {
                NotFound("404 error");
            }

            var client = _dbContext.Rooms.Find(id);

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
        public async Task<IActionResult> Edit(string id,  Room room)
        {
            if (room.RoomId == null)
            {
                NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Rooms.Update(room);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (room.RoomId == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("GetAllPost", "Room");
            }
            return View(room);
        }
  



    
            [HttpGet]
            public IActionResult Delete(string id)
            {

                if (id == null)
                {
                    NotFound("404 error");
                }

                var room = _dbContext.Rooms.Find(id);

                if (room == null)
                {
                    NotFound("404 error");
                }
                return View(room);
            }

            /// <summary>
            /// I ndryshon te dhenat e useri pasi aij te klikon buttonin update...
            /// </summary>
            /// <param name="id"></param>
            /// <param name="client"></param>
            /// <returns></returns>
            [HttpPost]
            public IActionResult Delete(string id, Room room)
            {
                if (room.RoomId == null)
                {
                    NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                         _dbContext.Rooms.Remove(room);
                         _dbContext.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (room.RoomId == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("GetAllPost", "Room");
                }
                return View(room);
            }

    }
}
