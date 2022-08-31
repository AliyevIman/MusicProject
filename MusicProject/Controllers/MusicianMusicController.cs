using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianMusicController : ControllerBase
    {
        private readonly IMusicianMusicManager _manager;

        public MusicianMusicController(IMusicianMusicManager manager)
        {
            _manager = manager;
        }
        [HttpGet("GetAll")]
        public List<MusiciansMusic> GetAll()
        {
            return _manager.GetAll();
        }
    }
}
