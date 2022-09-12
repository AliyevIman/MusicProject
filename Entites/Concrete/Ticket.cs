using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public long Price{ get; set; }
        public long Discount { get; set; }
        public List<Order> Orders { get; set; }
    }
}