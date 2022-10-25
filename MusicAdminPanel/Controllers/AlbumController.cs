using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicAdminPanel.Controllers
{
    public class AlbumController : Controller
    {
        // GET: AlbumController
        //private readonly IMusicianManager _musicianManager;
        private readonly IAlbumManager _manager;
        private readonly IWebHostEnvironment _env;
        public AlbumController(IAlbumManager manager, IWebHostEnvironment env)
        {
            _manager = manager;
            _env = env;
            //_musicianManager = musicianManager;
        }
        public ActionResult Index()
        {
            var data = _manager.GetAll();
            return View(data);
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(int Id)
        {
        //if (Id == null)
            //{
            //    return NotFound();
            //}

            var music = _manager.GetMuicById(Id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            //ViewBag.Musician = _musicianManager.GetAllMusician();   
            return View();
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Albums album, IFormFile AlbumPhoto)
        {
            try
            {
                if (AlbumPhoto != null)
                {
                    string filename = Guid.NewGuid() + AlbumPhoto.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    AlbumPhoto.CopyTo(fl);
                    album.AlbumPhoto = "/images/" + filename;
                }

                //_context.Add(music);
                //await _context.SaveChangesAsync();
                _manager.Create(album);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(album);
            }
            return View(album);
        }

        // GET: AlbumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlbumController/Edit/5
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

        // GET: AlbumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlbumController/Delete/5
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
