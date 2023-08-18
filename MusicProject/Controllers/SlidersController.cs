using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderManager _manager;

        public SlidersController(ISliderManager manager)
        {
            _manager = manager;
        }


        [HttpGet("GetSlider")]
        public async Task<Slider> GetSlider()
        {
            var slider = await _manager.Get();
            return slider;
        }
    }
}
