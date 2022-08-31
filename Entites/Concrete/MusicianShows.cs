using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public  class MusicianShows :IEntity
    {
        public int Id { get; set; }
        public int LiveShowsId { get; set; }
        public  LiveShows LiveShows { get; set; }
        public int MusiciansId { get; set; }
        public Musician Musicians { get; set; }
    }
}