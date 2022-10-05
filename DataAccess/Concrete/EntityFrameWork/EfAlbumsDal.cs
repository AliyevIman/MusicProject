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
    public class EfAlbumsDal : IEntityRepository<MusicDbContext, Albums>, IAlbumsDal
    {
        public void Create(Albums album)
        {
            using MusicDbContext context = new();
            context.Albums.Add(album);
            context.SaveChanges();
        }

        public Albums GetAlbumsById(int albumId)
        {
            using MusicDbContext _context = new();
            return _context.Albums.Include(c => c.Musician).ThenInclude(x => x.Musics).ThenInclude(s => s.Music).FirstOrDefault(c => c.Id == albumId);
        }

        public List<Albums> GetAlbumsWithMusic()
        {
            using MusicDbContext _context = new();
            return _context.Albums.Include(c => c.Music).Include(c=>c.Musician).ToList();
        }

        public async Task<Albums> GetMusicByAlbum(int albumId)
        {
            using MusicDbContext _context = new();
            return await _context.Albums.Include(c => c.Musician).ThenInclude(x => x.Musics).ThenInclude(s => s.Music).FirstOrDefaultAsync(c => c.Id == albumId);
        }
    }
}