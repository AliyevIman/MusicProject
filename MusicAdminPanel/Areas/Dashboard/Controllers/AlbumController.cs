using AutoMapper;
using Business.Abstract;
using Business.Settings;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicAdminPanel.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]

    public class AlbumController : Controller
    {
        // GET: AlbumController
        //private readonly IMusicianManager _musicianManager;
        private readonly IAlbumManager _manager;
        private readonly IPictureSettings _pictureSettings;
        private readonly IMapper _mapper;

        private readonly IWebHostEnvironment _env;
        public AlbumController(IAlbumManager manager, IWebHostEnvironment env, IPictureSettings pictureSettings, IMapper mapper)
        {
            _manager = manager;
            _env = env;
            _pictureSettings = pictureSettings;
            _mapper = mapper;
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
        public ActionResult Create(AlbumListDTO album, IFormFile AlbumPhoto)
        {
            try
            {
                var maper = _mapper.Map<Albums>(album);
                _pictureSettings.Add(AlbumPhoto);


                //_context.Add(music);
                //await _context.SaveChangesAsync();
                _manager.Create(maper);
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
            if (id == null) return NotFound();
            var data = _manager.GetMuicById(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // POST: AlbumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id == null)
            {
                return NotFound();
            }

            _manager.DeleteAlbum(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
