using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class AlbumMusicanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Photo { get; set; }
        public bool IsNew { get; set; }
        public List<MusiciansMusicDTO> Musics { get; set; }
    }
}