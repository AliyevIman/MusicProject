using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class MusicianShowsDTO
    {
        public int LiveShowsId { get; set; }
        public int MusiciansId { get; set; }
        public LiveShowDTO LiveShows { get; set; }
        public MusicianLiveShowDTO Musicians { get; set; }
    }
}