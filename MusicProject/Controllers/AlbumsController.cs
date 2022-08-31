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
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumManager _manager;
        private readonly IMapper _mapper;
        public AlbumsController(IAlbumManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public List<ALbumDTO> GetAll()
        {
            var list = _manager.GetAll();
            var map = _mapper.Map<List<ALbumDTO>>(list);
            return map;
        }
        [HttpGet("albums/{albumId}")]
        public List<ALbumDTO> GetMusicByID( int? albumId)
        {
            if (!albumId.HasValue) return null;
            var list = _manager.GetMuicById(albumId.Value);
            var map = _mapper.Map<List<ALbumDTO>>(list);
            return map.ToList();
        }
    }
}
