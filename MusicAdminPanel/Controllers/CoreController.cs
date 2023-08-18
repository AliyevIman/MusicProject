using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MusicAdminPanel.Controllers
{
    public class CoreController : Controller
    {
        private readonly IPictureSettings _pictureService;

        public CoreController(IPictureSettings pictureService)
        {
            _pictureService = pictureService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UploadPictures()
        {
            JsonResult res = new(new() { });
            var img = Request.Form.Files[0];
            if (img != null)
            {
                List<string> imgList = new();
                    var picture = await _pictureService.Add(img);
                if (picture.Success) imgList.Add(picture.Data);
                res.Value = imgList;
                return Json(res);
            }
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> UploadMusic()
        {
            JsonResult res = new(new() { });
            var audio = Request.Form.Files[0];
            if (audio != null)
            {
                List<string> audioList = new();
                var music = await _pictureService.AddMusic(audio);
                if (music.Success) audioList.Add(music.Data);
                res.Value = audioList;
                return Json(res);
            }
            return Json(res);
        }


        private async void RecordInSession(string action)
        {
            HttpContext.Session.SetString("Lang", action);
        }
    }
}
