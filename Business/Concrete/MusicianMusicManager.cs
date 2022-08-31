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
    public class MusicianMusicManager : IMusicianMusicManager
    {
        private readonly IMuscianMusicDal _dal;

        public MusicianMusicManager(IMuscianMusicDal dal)
        {
            _dal = dal;
        }

        public List<MusiciansMusic> GetAll()
        {
            return _dal.GetAllMusicianMusic();
        }
    }
}
