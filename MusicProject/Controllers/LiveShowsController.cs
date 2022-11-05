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
    public class LiveShowsController : ControllerBase
    {
        private readonly ILiveShowsManager _manager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public LiveShowsController(ILiveShowsManager manager, IMapper mapper, IWebHostEnvironment environment)
        {
            _manager = manager;
            _mapper = mapper;
            _environment = environment;
        }
        [HttpGet("GetAll")]
        public List<LiveShowDTO> GetAll()
        {
            var list = _manager.GetLiveShowsWithMusician();
            var map=  _mapper.Map<List<LiveShowDTO>>(list);
            return map;
        }
        [HttpGet("{id}")]
        public async Task<LiveShowDTO> GetById(int id)
        {

            var list = await _manager.GetById(id);
            var map = _mapper.Map<LiveShowDTO>(list);
            return map;
        }
        [HttpPost("AddLive")]
        public async Task<JsonResult> Add(LiveShowDTO live)
        {
            JsonResult res = new(new { });
            try
            {
                var _mapperMusic = _mapper.Map<LiveShows>(live);
                _manager.Create(_mapperMusic);
                res.Value = new { status = 200, message = "Live Show added successfully" };
            }
            catch (Exception e)
            {
                res.Value = new { status = 400, errors = e.Message };
            }
            return res;

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
