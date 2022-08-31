using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfMusicianShowDal : EFEntityRepositoryBase<MusicDbContext, MusicianShows>, IMusiciansShowsDal
    {
        public List<MusicianShows> GetAllLives()
        {
            using MusicDbContext musicDbContext = new();
            return musicDbContext.MusicianShows
                .Include(c => c.LiveShows)
                .Include(i => i.Musicians)
                .Where(x => x.LiveShowsId == x.LiveShows.Id)
                .ToList();
        }
    }
}