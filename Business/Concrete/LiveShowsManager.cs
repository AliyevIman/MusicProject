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

        public Task<LiveShows> GetById(int id)
        {
            if (id == null) return null;
            return _dal.GetById(id);
        }

        public List<LiveShows> GetLiveShowsWithMusician()
        {
            return _dal.GetLiveShowsMusicans();
        }
    }
}
