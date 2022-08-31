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
    public class LiveShowsManager : ILiveShowsManager
    {
        private readonly ILiveShowsDal _dal;

        public LiveShowsManager(ILiveShowsDal dal)
        {
            _dal = dal;
        }

        public List<LiveShows> GetLiveShowsWithMusician()
        {
            return _dal.GetLiveShowsMusicans();
        }
    }
}
