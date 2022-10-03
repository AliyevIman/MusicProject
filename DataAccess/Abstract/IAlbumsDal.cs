using Core;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAlbumsDal :IEntityRepository<Albums>
    {
        List<Albums> GetAlbumsWithMusic();
        Albums GetAlbumsById( int albumId);
        Task<Albums> GetMusicByAlbum( int albumId);
        void Create (Albums album); 
    }
}