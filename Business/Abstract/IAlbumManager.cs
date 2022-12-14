using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAlbumManager
    {
        List<Albums> GetAll();
        Albums GetMuicById(int albumId);
        Task<Albums> GetMusicByAlbum(int albumId);
        void Create (Albums album);
        Task<Albums> GetAlbumMusic(string userId, int albumId);
        void DeleteAlbum(int id);

    }
}
