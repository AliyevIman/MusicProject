using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MusicAdminPanel.Areas.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        [Area("dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
