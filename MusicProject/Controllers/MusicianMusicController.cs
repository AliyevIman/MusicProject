using Business.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        //[HttpGet("GetMusicMusician")]
        //public List<User> GetMusicMusician()
        //{
        //    using MusicDbContext context = new();
        //    //var a = context.Users.Include

        //    //var map = _map.Map<List<MusicianToMusicDTO>>(list);
        //    return a;

        //}
    }
}
