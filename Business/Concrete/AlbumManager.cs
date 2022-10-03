using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AlbumManager : IAlbumManager
    {
        private readonly IAlbumsDal _dal;

        public AlbumManager(IAlbumsDal dal)
        {
            _dal = dal;
        }

        public void Create(Albums album)
        {
            _dal.Create(album);
        }

        public List<Albums> GetAll()
        {
            return _dal.GetAlbumsWithMusic();
        }

        public Albums GetMuicById(int albumId)
        {
            return _dal.GetAlbumsById(albumId);
        }

        public Task<Albums> GetMusicByAlbum(int albumId)
        {
            if (albumId == null) return null;
            return _dal.GetMusicByAlbum(albumId);
        }
    }
}
