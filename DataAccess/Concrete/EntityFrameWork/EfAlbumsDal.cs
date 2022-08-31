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
    public class EfAlbumsDal : EFEntityRepositoryBase<MusicDbContext, Albums>, IAlbumsDal
    {
        public List<Albums> GetAlbumsById(int albumId)
        {
            using MusicDbContext _context = new();
            return _context.Albums.Where(c => c.Id == albumId).Include(c => c.Musician).ThenInclude(x => x.Musics).ThenInclude(s => s.Music).ToList();
        }

        public List<Albums> GetAlbumsWithMusic()
        {
            using MusicDbContext _context = new();
            return _context.Albums.Include(c=>c.Musician).ThenInclude(x=>x.Musics).ThenInclude(s=>s.Music).ToList();
        }
    }
}