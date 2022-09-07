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
    public class EfMusicDal : EFEntityRepositoryBase<MusicDbContext, Music>, IMusicDal
    {
        //public Music GetFeatureMusic()
        //{
        //    using MusicDbContext context = new();
        //    return context.Musics.Where(c => c.IsFeatured == true).Include(c=>c.Musicians).ThenInclude(x=>x.Musician).ThenInclude(x=>x.Albums).First();
        //}

        public List<Music> GetMusics()
        {
            using MusicDbContext context = new();
            return context.Musics.ToList();
        }

        public List<Music> GetMusicsAll()
        {
            using MusicDbContext context = new();
            return context.Musics.ToList();
        }
    }
}
