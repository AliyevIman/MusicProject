using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public  class Musician :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Photo { get; set; }
        public bool IsNew { get; set; }
        public List<Albums> Albums { get; set; }
        public List<MusiciansMusic> Musics { get; set; } 
        public List<MusicianShows> LiveShow { get; set; }  
    }
}