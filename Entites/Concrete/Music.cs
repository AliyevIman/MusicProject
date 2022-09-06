﻿using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Music :IEntity
    {
        public int  Id { get; set; }
        public string Name { get; set; }    
        public string MusicUrl { get; set; }
        public string MusicVideo { get; set; }
        public string EndTime { get; set; }
        public DateTime PublishDate { get; set; }
        public string Photo { get; set; }
        public string AuthorName { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsDeleted { get; set; }
        public  List<MusiciansMusic>? Musicians{ get; set; }
    }
}