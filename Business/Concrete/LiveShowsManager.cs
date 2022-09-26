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

        public void Create(LiveShows liveShow)
        {
            
             _dal.Create(liveShow);
        }

        public void DeleteLive(int id)
        {
            var getMusic = _dal.Get(c => c.Id == id && !c.IsDeleted);
            if (getMusic != null)
            {
                getMusic.IsDeleted = true;
                _dal.Update(getMusic);
            }
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

        public void Update(int id, LiveShows liveShow)
        {
             _dal.UpdateLive(id, liveShow);
        }
    }
}
