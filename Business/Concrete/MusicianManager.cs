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
    public class MusicianManager : IMusicianManager
    {
        private readonly IMusicianDal _dal;

        public MusicianManager(IMusicianDal dal)
        {
            _dal = dal;
        }

        public List<Musician> GetAll()
        {
            return _dal.GetMusicians();
        }

        public List<Musician> GetMusicMusician()
        {
            return _dal.GetMusicMusician();
        }
    }
}
