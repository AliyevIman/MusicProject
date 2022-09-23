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
        public void Create(Music music)
        {
            using MusicDbContext context = new();
            context.Musics.Add(music);
            context.SaveChanges();
        }

        public void Delete(int musicId)
        {
            using MusicDbContext _context = new();

            var music =  _context.Musics.Find(musicId);
            _context.Musics.Remove(music);
             _context.SaveChangesAsync();
        }

        public Music GetMusicById(int? musicId)
        {
            using MusicDbContext _context = new();
            return _context.Musics.Where(c=>!c.IsDeleted).SingleOrDefault(c => c.Id == musicId);
        }

        //public Music GetFeatureMusic()
        //{
        //    using MusicDbContext context = new();
        //    return context.Musics.Where(c => c.IsFeatured == true).Include(c=>c.Musicians).ThenInclude(x=>x.Musician).ThenInclude(x=>x.Albums).First();
        //}

        public List<Music> GetMusics()
        {
            using MusicDbContext context = new();
            return context.Musics.Where(c => !c.IsDeleted).ToList();
        }

        public List<Music> GetMusicsAll()
        {
            using MusicDbContext context = new();
            return context.Musics.Where(c => !c.IsDeleted).ToList();
        }
    }
}
