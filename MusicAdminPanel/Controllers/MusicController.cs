using Business.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MusicAdminPanel.Controllers
{
    public class MusicController : Controller
    {
        private readonly IMusicManager _manager;
        private readonly IWebHostEnvironment _env;


        public MusicController(IMusicManager manager, IWebHostEnvironment env)
        {
            _manager = manager;
            _env = env;
        }


        // GET: MusicController
        public ActionResult  Index()
        {
            var data = _manager.GetMusics();
            return  View( data);
        }

        // GET: MusicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public   IActionResult Create(Music music , IFormFile Photo,IFormFile MusicUrl)
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
                    music.Photo = "/images/" + filename;
                }
                if (MusicUrl != null)
                {
                    string filename = Guid.NewGuid() + MusicUrl.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "music");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    MusicUrl.CopyTo(fl);
                    music.MusicUrl = "/music/" + filename;
                }
                //_context.Add(music);
                //await _context.SaveChangesAsync();
                _manager.AddMusic(music);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

            return View(music);

            }
            return View(music);

        }

        // GET: MusicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicController/Edit/5
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

        // GET: MusicController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var data = _manager.GetMusicById(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // POST: MusicController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
                
                _manager.Delete(id);
                return RedirectToAction(nameof(Index));

        }
    }
}
