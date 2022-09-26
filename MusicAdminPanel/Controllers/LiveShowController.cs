using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicAdminPanel.Controllers
{
    public class LiveShowController : Controller
    {
        // GET: LiveShowController
        private readonly ILiveShowsManager _manager;
        private readonly IMusicianManager _musician;
        private readonly IWebHostEnvironment _env;
        public LiveShowController(ILiveShowsManager manager, IMusicianManager musician, IWebHostEnvironment env)
        {
            _manager = manager;
            _musician = musician;
            _env = env;
        }

       
        public ActionResult Index()
        {
            ViewBag.Musician = _musician.GetAllMusician();
            var data = _manager.GetLiveShowsWithMusician();
            return View(data);
        }

        // GET: LiveShowController/Details/5
        public async  Task<IActionResult> Details(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var live = await _manager.GetById(Id);
            if (live == null)
            {
                return NotFound();
            }

            return   View(live);
        }

        // GET: LiveShowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiveShowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LiveShowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LiveShowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LiveShowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LiveShowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
