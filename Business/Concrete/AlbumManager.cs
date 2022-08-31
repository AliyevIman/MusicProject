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

        public List<Albums> GetAll()
        {
            return _dal.GetAlbumsWithMusic();
        }

        public List<Albums> GetMuicById(int albumId)
        {
            return _dal.GetAlbumsById(albumId);
        }
    }
}
