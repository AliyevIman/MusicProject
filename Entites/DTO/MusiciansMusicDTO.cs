using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class MusiciansMusicDTO
    {
       
        public int MusicId { get; set; }
        public virtual MusicAlbumDTO Music { get; set; }
    }
}