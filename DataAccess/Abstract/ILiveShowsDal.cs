using Core;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILiveShowsDal :IEntityRepository<LiveShows>
    {
        List<LiveShows> GetLiveShowsMusicans();
        Task<LiveShows> GetById(int id);
        void Create(LiveShows liveShow);
        void UpdateLive(int id, LiveShows liveShow);


    }
}
