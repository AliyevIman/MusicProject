using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class AlbumToUserDTO
    {
        public string Name { get; set; }
        public string? AlbumPhoto { get; set; }
        public DateTime RealizeDate { get; set; }
        public string? RecordLable { get; set; }
        public string? SongCount { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsFeatured { get; set; }
        //
        //[ForeignKey(nameof(User))]
        public string UserId { get; set; }
    }
}
