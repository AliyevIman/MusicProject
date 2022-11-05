using AutoMapper;
using Business.Abstract;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotenv.net;
namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        //public ImageUploadResult Upload(ImageUploadParams parameters);

        private readonly IAlbumManager _manager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IPictureSettings _pictureSettings;
        public AlbumsController(IAlbumManager manager, IMapper mapper, IWebHostEnvironment environment, IPictureSettings pictureSettings)
        {
            _manager = manager;
            _mapper = mapper;
            _environment = environment;
            _pictureSettings = pictureSettings;
        }

        [HttpGet("GetAlbumMusic/{userId}/{albumId}")]
        public async Task<AlbumWithMusicDTO> GetAlbumMusic(string userId,int albumId)
        {
            var list = await _manager.GetAlbumMusic(userId, albumId);
            var map =_mapper.Map<AlbumWithMusicDTO>(list);
            return map;
        }

        [HttpGet("GetAll")]
        public List<AlbumWithMusicDTO> GetAll()
        {
            var list = _manager.GetAll();
            var map = _mapper.Map<List<AlbumWithMusicDTO>>(list);
            return map;
        }
        [HttpGet("albums/{albumId}")]
        public List<ALbumDTO>? GetMusicByID( int? albumId)
        {
            if (!albumId.HasValue) return null;
            var list = _manager.GetMuicById(albumId.Value);
            var map = _mapper.Map<List<ALbumDTO>>(list);
            return map.ToList();
        }
        [HttpGet("music/{albumId}")]
        public async Task<AlbumWithMusicDTO> GetById(int? albumId)
        {
            if (!albumId.HasValue) return null;
            var list = await _manager.GetMusicByAlbum(albumId.Value);
            var map = _mapper.Map<AlbumWithMusicDTO>(list);
            return map;

        }
        [HttpPost("AddAlbum")]
        public async Task<JsonResult> Add(AlbumToUserDTO album)
        {
            JsonResult res = new(new { });
            try
            {
                var _mapperMusic = _mapper.Map<Albums>(album);
                _manager.Create(_mapperMusic);
                res.Value = new { status = 200, message = "Album added successfully" };
            }
            catch (Exception e)
            {
                res.Value = new { status = 400, errors = e.Message };
            }
            return res;

        }
     
        [HttpPost("uploadcover")]
        public  string UploadPhotoAsync(IFormFile Image)
        {
            return _pictureSettings.Add(Image);
            
            //    Console.WriteLine(uploadResult.JsonObj);

            //    //
            //    string path = "/files/" + Guid.NewGuid() + Image.FileName;
            //    using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            //    {
            //        await Image.CopyToAsync(fileStream);
            //    }
            //    return Ok(new { status = 200, message = path });
        }

    }
}