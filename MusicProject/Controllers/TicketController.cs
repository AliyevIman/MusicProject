using AutoMapper;
using Business.Abstract;
using Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
       private readonly ITicketManager _manager;
        private readonly IMapper _map;

        public TicketController(ITicketManager _manager, IMapper map)
        {
            this._manager = _manager;
            _map = map;
        }
        [HttpGet("{id}")]
        public async Task<TicketDTO> Get(int? id)
        {
            if (id == null) return null;
            var list = _manager.GetById(id.Value);
            var map = _map.Map<TicketDTO>(list);
            return map;

        }
    }
}
