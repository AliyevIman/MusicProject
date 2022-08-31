using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MusicianShowsManager : IMusicianShowManager
    {
        private readonly IMusiciansShowsDal _dal;

        public MusicianShowsManager(IMusiciansShowsDal dal)
        {
            _dal = dal;
        }

        public List<MusicianShows> GetMusicianShows()
        {
            return _dal.GetAllLives();
        }
    }
}
