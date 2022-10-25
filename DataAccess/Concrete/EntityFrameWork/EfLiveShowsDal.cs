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
    public class EfLiveShowsDal : EfEntityRepositoryBase<MusicDbContext, LiveShows>, ILiveShowsDal
    {
        public void Create(LiveShows liveShow)
        {
            using MusicDbContext context = new();
            context.LiveShows.Add(liveShow);
            context.SaveChanges();
        }

        public async Task<LiveShows> GetById(int id)
        {
            using MusicDbContext context = new();
            return await context.LiveShows.Include(c => c.Musicians).FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            //.ThenInclude(c => c.Musicians)

        }

        public List<LiveShows> GetLiveShowsMusicans()
        {
            using MusicDbContext context = new();
            return context.LiveShows
                .Include(c => c.Musicians)
                 .Where(c => !c.IsDeleted)
                .ToList();
        }

        public void UpdateLive(int id, LiveShows liveShow)
        {
            using MusicDbContext context = new();
            liveShow.Id = id;
            var singleCourse = GetById(id);

            //context.RemoveRange(singleCourse.AlbumsId);
            //context.Specifactions.RemoveRange(singleCourse.CourseSpecifactions.Where(c=>c.CourseId==id).ToArray());
            context.LiveShows.Update(liveShow);
            context.SaveChanges();
        }
    }
}