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

        private readonly IMapper _map;
        public MusicianController(UserManager<User> manager, IMapper map, RoleManager<IdentityRole> roleManager)
        {
            _manager = manager;
            _map = map;
            _roleManager = roleManager;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _manager.GetUsersInRoleAsync("Artist");
            //var list = _roleManager.Roles.Where(c => c. == X"Artist").ToList();


            //var map = _map.Map<List<MusicianDTO>>(list);
            return Ok(list);
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
        //[HttpGet("GetAllMusician")]
        //public List<MusicianListDTO> GetAllMusician()
        //{
        //    var list = _manager.GetAll();
        //var map = _map.Map<List<MusicianListDTO>>(list);
        //    return map;
        //}

    }
}
