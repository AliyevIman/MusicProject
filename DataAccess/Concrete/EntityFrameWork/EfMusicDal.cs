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
    public class EfMusicDal : EfEntityRepositoryBase<MusicDbContext, Music>, IMusicDal
    {
        public void Create(Music music)
        {
            using MusicDbContext context = new();
            context.Musics.Add(music);
            context.SaveChanges();
        }

        public List<Music> GetAll()
        {
            using MusicDbContext _context = new();
            return _context.Musics.Where(c => !c.IsDeleted).Include(c => c.Album).ToList();
        }

        public Music GetMusicById(int? musicId)
        {
            using MusicDbContext _context = new();

            return _context.Musics.Include(c=>c.Album).Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == musicId);
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

        public  void UpdateMusic(int id, Music music)
        {
                using MusicDbContext context = new();
                music.Id = id;
                var singleCourse =  GetMusicById(id);

                //context.RemoveRange(singleCourse.AlbumsId);
                //context.Specifactions.RemoveRange(singleCourse.CourseSpecifactions.Where(c=>c.CourseId==id).ToArray());
                context.Musics.Update(music);
                context.SaveChanges();
        }
    }
}
