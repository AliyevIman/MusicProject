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
        public  ActionResult Details(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var music = _manager.GetMusicById(Id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
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
            if (id == null)
            {
                return NotFound();
            }

            var music = _manager.GetMusicById(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        // POST: MusicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,name,photo,musicUrl,musicVideo,authorName")] Music music)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

                try
                {
                    _manager.Udpdate(id,music);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(music);
                }
                return RedirectToAction(nameof(Index));
            //return View(music);
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
        public ActionResult DeleteConfrimed(int? Id)
        {
            if (Id ==null)
            {
                return NotFound();
            }

            _manager.DeleteMusic(Id.Value);
               return RedirectToAction(nameof(Index));

        }
    }
}
