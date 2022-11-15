using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MusicAdminPanel.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderManager _manager;
        private readonly IPictureSettings _pictureService;

        public SliderController(ISliderManager manager, IPictureSettings pictureService)
        {
            _manager = manager;
            _pictureService = pictureService;
        }

        public ActionResult Index()
        {
            var data = _manager.GetAll();
            return View(data);
        }

        // GET: LiveShowController/Details/5
        public IActionResult Details(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var live =  _manager.GetById(Id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // GET: LiveShowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiveShowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider? slider)
        {
            try
            {


                _manager.Creat(slider);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {

                return View(slider);

            }
            return View(slider);
        }

        // GET: LiveShowController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live =  _manager.GetById(id);
            if (live == null)
            {
                return NotFound();
            }
            return View(live);
        }

        // POST: LiveShowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider)
        {

            _manager.Update( slider);
            return RedirectToAction("Index");
        }

        // GET: LiveShowController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();
            var data =  _manager.GetById(id);
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

            _manager.DeleteSlider(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
