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
    public class MusicianShowController : ControllerBase
    {
        private readonly IMusicianShowManager _manager;
        private readonly IMapper _mapper;
        public MusicianShowController(IMusicianShowManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public List<MusicianShowsDTO> GetALl()
        {
            var list = _manager.GetMusicianShows();
            var map = _mapper.Map<List<MusicianShowsDTO>>(list);
            return map;
        }
    }
}
