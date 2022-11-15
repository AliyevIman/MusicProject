using AutoMapper;
using Business.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _manager;
        private readonly IWebHostEnvironment _environment;

        private readonly IMapper _map;
        public MusicianController(UserManager<User> manager, IMapper map, RoleManager<IdentityRole> roleManager, IWebHostEnvironment environment)
        {
            _manager = manager;
            _map = map;
            _roleManager = roleManager;
            _environment = environment;
        }
        [HttpGet("GetAll")]
        public async Task<List<MusicianListDTO>>  GetAll()
        {
            
            var list = await _manager.GetUsersInRoleAsync("Artist");
            var map =  _map.Map<List<MusicianListDTO>>(list);
            
            //var list = _roleManager.Roles.Where(c => c. == X"Artist").ToList();


            //var map = _map.Map<List<MusicianDTO>>(list);
            return map;
        }

        [HttpGet("GetMusicMusician/{userId}")]
        public async Task<MusicianToMusicDTO> GetMusicMusician(string userId)
        {

            using MusicDbContext context = new();

            //var list = await _manager.GetUsersInRoleAsync("Artist");
            //var a = await _manager.FindByIdAsync(userId);
            //var c= await _manager;
            //var c = a.Musics;
            var b = context.Users.Include(c => c.Musics).ThenInclude(c => c.Music).FirstOrDefault(c => c.Id == userId);

            var map = _map.Map<MusicianToMusicDTO>(b);
            //return list.Where(c => c.Musics.Any()).ToList();
            return map;
        }

        [HttpGet("GetMusicianAlbum/{userId}")]
        public async Task<MusicianAlbumsDTO> GetAlbumMusician(string userId)
        {
            using MusicDbContext context = new();

            //var list = await _manager.GetUsersInRoleAsync("Artist");
            //var a = await _manager.FindByIdAsync(userId);
            //var c= await _manager;
            //var c = a.Musics;
            var b = context.Users.Include(c => c.Albums).FirstOrDefault(c => c.Id == userId);

            var map = _map.Map<MusicianAlbumsDTO>(b);
            //return list.Where(c => c.Musics.Any()).ToList();
            return map;
        }



        [HttpGet("GetAllUserAlbum")]
        public async Task<List<MusicianAlbumsDTO>> GetAllUserAlbum()
        {
            using MusicDbContext context = new();

            //var list = await _manager.GetUsersInRoleAsync("Artist");
            //var a = await _manager.FindByIdAsync(userId);
            //var c= await _manager;
            //var c = a.Musics;
            var b = context.Users.Include(c => c.Albums).ToList();

            var map = _map.Map<List<MusicianAlbumsDTO>>(b);
            //return list.Where(c => c.Musics.Any()).ToList();
            return map;
        }
        [HttpPost("uploadcover")]
        public async Task<IActionResult> UploadPhotoAsync(IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            return Ok(new { status = 200, message = path });
        }


        [HttpPost("uploadimages")]
        public async Task<IActionResult> UploadImagesAsync(IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            List<string> photos = new();

            return Ok(new { status = 200, message = path });
        }
    }
}
