using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class LiveShowDTO
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public string Loacation { get; set; }
        public string TicketCount { get; set; }
        public List<MusicianShowsDTO> Musicians { get; set; }
    }
}