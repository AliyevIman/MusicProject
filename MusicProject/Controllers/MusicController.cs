using AutoMapper;
using Business.Abstract;
using Business.Settings;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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
        private readonly IWebHostEnvironment _environment;
        private readonly IMusicSettings _musicSettings;
        public MusicController(IMusicManager manager, IMapper map, IWebHostEnvironment environment, IMusicSettings musicSettings)
        {
            _manager = manager;
            _map = map;
            _environment = environment;
            _musicSettings = musicSettings;
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

        [HttpPost("AddMusic")]
        public async Task<JsonResult> Add(MusicAlbumDTO music)
        {
            JsonResult res = new(new { });
            try
            {
                var _mapperMusic = _map.Map<Music>(music);
                _manager.AddMusic(_mapperMusic);
                res.Value = new { status = 200, message = "music added successfully" };
            }
            catch (Exception e)
            {
                res.Value = new { status = 400, errors = e.Message };
            }
            return res;

        }

        [HttpPut("{id}")]
        public JsonResult Put(int? id, [FromBody] MusicAlbumDTO muisc)
        {
            JsonResult res = new(new { });
            if (id == null)
            {
                res.Value = new { status = 403, message = "Id is required" };
                return res;
            };
            var _mapperCourse = _map.Map<MusicAlbumDTO, Music>(muisc);
            _manager.Udpdate(id.Value, _mapperCourse);
            res.Value = new { status = 200, music = muisc };
            return res;
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int? id)
        {
            JsonResult res = new(new { });

            if (!id.HasValue)
            {
                res.Value = new { status = 404 };
                return res;
            }   

            try
            {
                _manager.DeleteMusic(id.Value);
                res.Value = new { status = 200 };

            }
            catch (Exception e)
            {
                res.Value = new { status = 403, message = e.Message };

            }


            return res;

        }
        [HttpPost("uploadMusic")]
        public string UploadPhotoAsync(IFormFile Image)
        {
            return _musicSettings.AddMusic(Image);
        }
 
    }   
}