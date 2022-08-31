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
    public class EfLiveShowsDal : EFEntityRepositoryBase<MusicDbContext, LiveShows>, ILiveShowsDal
    {
        public List<LiveShows> GetLiveShowsMusicans()
        {
            using MusicDbContext context = new();
            return context.LiveShows
                .Include(c=>c.Musicians)
                .ThenInclude(x=>x.Musicians)
                .ToList();
        }
    }
}