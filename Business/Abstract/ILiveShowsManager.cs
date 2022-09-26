using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILiveShowsManager 
    {
        List<LiveShows> GetLiveShowsWithMusician();
        Task<LiveShows> GetById(int id);
        void Create(LiveShows liveShow);
        void Update(int id,LiveShows liveShow);
        void DeleteLive(int id);

    }
}
