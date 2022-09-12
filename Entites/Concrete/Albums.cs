﻿using Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public  class Albums :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlbumPhoto { get; set; }
        public DateTime RealizeDate { get; set; }
        public string RecordLable { get; set; } 
        public string SongCount { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsFeatured { get; set; }
        public List<Music>? Music { get; set; }

        [ForeignKey(nameof(Musician))]
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
    }
}