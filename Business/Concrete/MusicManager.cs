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
    public class MusicManager : IMusicManager
    {
        private readonly IMusicDal _dal;

        public MusicManager(IMusicDal dal)
        {
            _dal = dal;
        }

        public List<Music> GetMusics()
        {
            return _dal.GetMusics();
        }
    }
}
