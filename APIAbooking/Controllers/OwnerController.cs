using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIAbooking.Models;
using APIAbooking.Services;
using APIAbooking.Services.OwnerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ReflectionIT.Mvc.Paging;

namespace APIAbooking.Controllers
{
    public class OwnerController : Controller
    {
        private readonly APIAbookingContext _dbContext;
        private readonly IService _iService;
        private readonly IOwnerService _ownerService;
        private readonly IStringLocalizer<OwnerController> _localizer;

        #region Constructor
        public OwnerController(
            APIAbookingContext db,
            IService service,
            IOwnerService ownerService,
            IStringLocalizer<OwnerController> localizer)
        {
            _dbContext = db;
            _ownerService = ownerService;
            _localizer = localizer;
        }
        #endregion
        #region Action Method
        
        [HttpGet]
        //[Route("clients/homepage/ClientId")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var idOwner = HttpContext.Session.GetString("Id"); 
            ViewBag.currentUser = HttpContext.Session.GetString("Name");
            var item = _dbContext.Rooms.AsNoTracking().OrderBy(x => x.RoomId);
            var model = await PagingList.CreateAsync(item, 4, page);
            return View(model);
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
        [HttpGet]
        public IActionResult Login() => View(nameof(Login));

        [HttpPost]
        public IActionResult Login(RoomOwner owner)
        {
            //_ownerService.EncryptPassword(Encoding , owner.Password);
            var result = _ownerService.Login(owner.Email, owner.Password);
            if (ModelState.IsValid)
            {
                if (result == null)
                {
                    ModelState.AddModelError("Password", _localizer["Email or password are wrong, enter again"].ToString());
                    return View(result);
                }
                else
                {
                    HttpContext.Session.SetString("Name", result.Name + " " + result.Lastname);
                    HttpContext.Session.SetString("Id", result.OwnerId);
                    return RedirectToAction("Index");
                }
            }
            return View(owner);
        }

        public IActionResult Create() => View(nameof(Create));

        [HttpPost]
        public IActionResult Create(RoomOwner owner)
        {
            if (ModelState.IsValid)
            {
                owner.OwnerId = _ownerService.GenerateIdRandom(owner.OwnerId);
                if (owner.OwnerId != null)
                {
                    var result = _ownerService.IfEmailExist(owner.Email);
                    if (result == false)
                    {
                        owner.Password = _ownerService.EncryptPassword(Encoding.UTF8, owner.Password);
                        _ownerService.Create(owner);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", _localizer["Now this email is used, please enter a new!"].ToString());
                        return View(owner);
                    }
                }
                return RedirectToAction("HomePage", owner);
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
    #endregion
}