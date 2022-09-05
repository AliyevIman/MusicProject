using AutoMapper;
using Business.Abstract;
using Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _manager;
        private readonly IMapper _mapper;
        public OrderController(IOrderManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public List<OrderTicketDTO> GetAll()
        {
            var list = _manager.GetAll();
            var map = _mapper.Map<List<OrderTicketDTO>>(list);
            return map;
        }
        [HttpGet("Order/{userId}")]
        public List<OrderTicketDTO> GetOrderByUser(string userId)
        {
            var list = _manager.GetOrderBYUser(userId);
            var map = _mapper.Map<List<OrderTicketDTO>>(list);
            return map;
        }
    }
}
