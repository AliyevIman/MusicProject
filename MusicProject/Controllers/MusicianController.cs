using AutoMapper;
using Business.Abstract;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianManager _manager;
        private readonly IMapper _map;
        public MusicianController(IMusicianManager manager, IMapper map)
        {
            _manager = manager;
            _map = map;
        }
        [HttpGet("GetAll")]
        public List<MusicianDTO> GetAll()
        {
            var list = _manager.GetAll();
            var map = _map.Map<List<MusicianDTO>>(list);
            return map;
        }
        [HttpGet("GetMusicMusician")]
        public List<MusicianToMusicDTO> GetMusicMusician()
        {
            var list = _manager.GetMusicMusician();
            var map = _map.Map<List<MusicianToMusicDTO>>(list);
            return map;

        }
        [HttpGet("GetAllMusician")]
        public List<MusicianListDTO> GetAllMusician()
        {
            var list = _manager.GetAll();
            var map = _map.Map<List<MusicianListDTO>>(list);
            return map;
        }

    }
}
