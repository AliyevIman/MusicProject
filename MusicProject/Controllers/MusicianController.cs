using AutoMapper;
using Business.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("GetMusicMusician")]
        public List<User> GetMusicMusician()
        {
            using MusicDbContext context = new();
            var a= context.Users
                .Include(c => c.Musics)
                .ThenInclude(s => s.Music)
                .ToList();
            
            //var map = _map.Map<List<MusicianToMusicDTO>>(list);
            return a;

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
