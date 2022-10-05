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
    public class EfMusicianMusicDal : IEntityRepository<MusicDbContext, MusiciansMusic>, IMuscianMusicDal
    {
        //public List<MusiciansMusic> GetAllMusicianMusic()
        //{
        //    using MusicDbContext context = new();
        //    return context.MusiciansMusic.Include(c => c.Musician).Include(s => s.Music).Where(x=>x.MusicianId==x.Musician.Id).ToList();
        //}
        public List<MusiciansMusic> GetAllMusicianMusic()
        {
            throw new NotImplementedException();
        }
    }
}
