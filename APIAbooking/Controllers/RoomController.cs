using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAbooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using ReflectionIT.Mvc.Paging;
using APIAbooking.Services.RoomService;
using APIAbooking.Services;
using Microsoft.AspNetCore.Http;

namespace APIAbooking.Controllers
{
    public class RoomController : Controller
    {
        private readonly APIAbookingContext _dbContext;
        private readonly IService _iService;
        private readonly IRoomService _roomService;
        public RoomController
            (APIAbookingContext db,
            IService service,
            IRoomService room
            )
        {
            _dbContext = db;
            _iService = service;
            _roomService = room;
        }

        //public async Task<IActionResult> Index(int page = 1)
        //{
        //    var item = _dbContext.Rooms.AsNoTracking().OrderBy(x => x.Price);
        //    var model = await PagingList<Room>.CreateAsync(item, 4, page);
        //    return View(model);
        //}

        public IActionResult DetalistOfRoom(string id)
        {
            if(id == null)
            {
                NotFound();
                return null;
            }
            else
            {
                //var room = _roomService.GetById(id);
                return View(_dbContext.Rooms.Where(x => x.RoomId ==id));
            }
            
        }
        public  IActionResult Booking(string id, Booking book)
        {
            
            if(id == null)
            {
              
                NotFound();
                return null;
            }
            else
            {
                var clientId = HttpContext.Session.GetString("Id");
                var booking = _roomService.CreateBooking(id, clientId, book);
                return View(booking);
            }
        }


        public IActionResult Create() => View(nameof(Create));

        [HttpPost]
        public IActionResult Create(Room room)
        {
           if(room != null)
            {
                room.OwnerIdFk = HttpContext.Session.GetString("Id");
                var result = _roomService.Create(room);
                return RedirectToAction(nameof(Index),"Onwer");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (ModelState.IsValid)
            {
                if(id == null)
                {
                    return View();
                }
                else
                {
                    var room = _roomService.GetById(id);
                    return View(room);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(string id, Room room)
        {
            if (ModelState.IsValid)
            {
                if (id != null)
                {
                    room = _roomService.Edit(id);

                    return RedirectToAction(nameof(Index),"Onwer");
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("GetAllPost", "Room");
        }


        [HttpGet]
    public IActionResult Delete(string id)
    {

        if(ModelState.IsValid)
        {
                if (id != null)
                {
                    var room = _roomService.Delete(id);
                    if (room.Equals(false))
                    {
                        ViewBag.Description = "You can't delete a room because this room is booking now. Please information guest that this room is not avaible for live!";
                        return RedirectToAction(nameof(Index), "Owner");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Room");
                    }
                }
                else
                {
                    return View();
                }
        }
        
        return RedirectToAction(nameof(Index), "Owner");
        }
    }
}
