using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicManager _manager;

        public MusicController(IMusicManager manager)
        {
            _manager = manager;
        }
        [HttpGet("GetMusic")]
        public List<Music> GetMusic()
        {
            return _manager.GetMusics();
        }
    }   
}
