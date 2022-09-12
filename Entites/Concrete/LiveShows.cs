using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class LiveShows :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public string Loacation { get; set; }
        public string Stock { get; set; }
        public bool IsDeleted { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string TicketCount { get; set; }
        public List<MusicianShows> Musicians { get; set; }
    }
}