using AutoMapper;
using Entites.Concrete;
using Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.MyAllProfiles
{
    public class MusicProfile :Profile
    {
        public MusicProfile()
        {
            CreateMap<Music, MusicAlbumDTO>().ForMember(
                    dest => dest.AlbumName,
                    opt => opt.MapFrom(src => src.Album.Name)
                 );
            CreateMap<Music, MusicDTO>();
            CreateMap<Music, MusicListDTO>();

        }
    }
}