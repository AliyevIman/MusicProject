using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MusicAdminPanel.Controllers
{
    public class LiveShowController : Controller
    {
        // GET: LiveShowController
        private readonly ILiveShowsManager _manager;
        private readonly IMusicianShowManager _musician;
        private readonly IWebHostEnvironment _env;
        public LiveShowController(ILiveShowsManager manager, IMusicianShowManager musician, IWebHostEnvironment env)
        {
            _manager = manager;
            _musician = musician;
            _env = env;
        }

       
        public ActionResult Index()
        {
            ViewBag.Musician = _musician.GetMusicianShows();
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
            ViewBag.Musician = _musician.GetMusicianShows();
            return View();
        }

        // POST: LiveShowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LiveShows liveShow ,IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    string filename = Guid.NewGuid() + Photo.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    Photo.CopyTo(fl);
                    liveShow.Photo = "/images/" + filename;
                }
              
                //_context.Add(music);
                //await _context.SaveChangesAsync();
                _manager.Create(liveShow);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View(liveShow);

            }
            return View(liveShow);
        }

        // GET: LiveShowController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _manager.GetById(id);
            if (live == null)
            {
                return NotFound();
            }
            return View(live);
        }

        // POST: LiveShowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,IFormFile Photo, LiveShows live)
        {
            if (Photo != null)
            {
                string FileName = Guid.NewGuid() + Photo.FileName;
                string RootPath = Path.Combine(_env.WebRootPath, "images");
                string PhotoPath = Path.Combine(RootPath, FileName);
                using FileStream fl = new (PhotoPath, FileMode.Create);
                Photo.CopyTo(fl);
                live.Photo = "/images/" + FileName;
            }
            _manager.Update(id,live);
            return RedirectToAction("Index");
        }

        // GET: LiveShowController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();
            var data = await _manager.GetById(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // POST: LiveShowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, IFormCollection collection)
        {
            if (Id == null)
            {
                return NotFound();
            }

            _manager.DeleteLive(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
