//using Core.DataAccess.EntityFramework;
//using DataAccess.Abstract;
//using Entites.Concrete;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccess.Concrete.EntityFrameWork
//{
//    public class EfMusicianDal : EfEntityRepositoryBase<MusicDbContext, IdentityUser>, IMusicianDal
//    {
//        //public List<Musician> GetAll()
//        //{
//        //    using MusicDbContext context = new();
//        //    return context.Musicians.ToList();
//        //}

//        public List<Musician> GetMusicians()
//        {
//            using MusicDbContext context = new();
//            return context..Include(c => c.Albums).Include(c => c.Musics).ThenInclude(x => x.Music).ToList();
//        }

//        //public List<Musician> GetMusicMusician()
//        //{
//        //    using MusicDbContext context = new();
//        //    return context.Musicians
//        //        .Include(c => c.Musics)
//        //        .ThenInclude(s => s.Music)
//        //        .ToList();
//        //}
//    }
//}