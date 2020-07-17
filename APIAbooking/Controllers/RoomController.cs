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

        
        public  IActionResult Booking(string id, Booking book)
        {
            id = null;
            if(id == null)
            {
              
                NotFound();
                return null;
            }
            else
            {
                book.BookId = "3";
                book.RoomIdFk = id;
                book.ClientIdFk = HttpContext.Session.GetString("Id"); 
                book.TypeIdFk = "3";
                 _dbContext.Bookings.Add(book);
                _dbContext.SaveChanges();
                return View(_dbContext.Bookings);
            }
        }


        public IActionResult Create() => View(nameof(Create));

        [HttpPost]
        public IActionResult Create(Room room)
        {
           if(room != null)
            {
                var result = _roomService.Create(room);
                return View(result);
            }
            else
            {
                return View();
            }
        }

        //public IActionResult GetAllPost(string owner_id) => View(_dbContext.Rooms.Where(x => x.OwnerIdFk == owner_id));



        //[HttpGet]
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        NotFound("404 error");
        //    }

        //    var client = _dbContext.Rooms.Find(id);

        //    if (client == null)
        //    {
        //        NotFound("404 error");
        //    }
        //    return View(client);
        //}

        /// <summary>
        /// I ndryshon te dhenat e useri pasi aij te klikon buttonin update...
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(string id)
        {
            if (ModelState.IsValid)
            {
               if (id != null)
                    {
                       var room = _roomService.Edit(id);

                       return RedirectToAction("GetAllPost", "Room");
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

                    return RedirectToAction("GetAllPost", "Room");
                }
                else
                {
                    return View();
                }
        }
        
        return RedirectToAction("GetAllPost", "Room");
    }
    }
}
