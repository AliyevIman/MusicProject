using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class MusicAlbumDTO
    {
        public string Name { get; set; }
        public string MusicUrl { get; set; }
        public string MusicVideo { get; set; }
        public DateTime PublishDate { get; set; }
        public string Photo { get; set; }
        public string AuthorName { get; set; }
        public bool IsFeatured { get; set; }
        public int? AlbumsId { get; set; }
        public List<UserMusicDTO> Musicians { get; set; }
    }
}