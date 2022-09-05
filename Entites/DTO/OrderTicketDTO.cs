using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class OrderTicketDTO
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public List<TicketDTO> Ticket { get; set; }
    }
}