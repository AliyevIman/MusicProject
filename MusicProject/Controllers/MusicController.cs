using AutoMapper;
using Business.Abstract;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicManager _manager;
        private readonly IMapper _map;
        public MusicController(IMusicManager manager, IMapper map)
        {
            _manager = manager;
            _map = map;
        }
        [HttpGet("GetMusic")]
        [Authorize(Roles = "Artist")]

        public List<Music> GetMusic()
        {
            return _manager.GetMusics();
        }
        [HttpGet("GetAll")]
        public List<MusicListDTO> GetAll()
        {
            var list = _manager.GetAllMusics();
            var map = _map.Map<List<MusicListDTO>>(list);
            return map ;
        }
    }   
}
