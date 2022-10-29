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
    public class AlbumProfile :Profile
    {
        public AlbumProfile()
        {
            CreateMap<Albums, ALbumDTO>();
            CreateMap<AlbumListDTO, Albums>().ReverseMap();
            CreateMap<Albums,AlbumWithMusicDTO>();
            CreateMap<AlbumToUserDTO, Albums>().ReverseMap();

        }
    }
}
