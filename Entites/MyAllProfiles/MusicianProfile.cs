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
    public class MusicianProfile :Profile
    {
        public MusicianProfile()
        {
            CreateMap<User, MusicianLiveShowDTO>();
            CreateMap<User, MusicianDTO>();
            CreateMap<User, MusicianListDTO>();
            CreateMap<User, MusicianToMusicDTO>();
            CreateMap<User, MusicianWithMusicDTO>();
            CreateMap<User, MusicianAlbumsDTO>();
            CreateMap<User, EditMusicianDTO>().ReverseMap();


        }
    }
}