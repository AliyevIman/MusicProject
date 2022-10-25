using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class UserDTO
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Biography { get; set; }
        public string Photo { get; set; }
        public bool IsNew { get; set; }
        public List<Albums>? Albums { get; set; }
        public List<MusiciansMusic>? Musics { get; set; }
        public List<MusicianShows>? LiveShow { get; set; }
    }
}
