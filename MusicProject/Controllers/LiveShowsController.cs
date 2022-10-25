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
        public LiveShowsController(ILiveShowsManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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
    }
}
