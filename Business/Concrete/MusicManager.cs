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
    public class MusicManager : IMusicManager
    {
        private readonly IMusicDal _dal;

        public MusicManager(IMusicDal dal)
        {
            _dal = dal;
        }

        public void AddMusic(Music music)
        {
            music.PublishDate = DateTime.Now;
            _dal.Create(music);
        }

        public void Delete(int musicId)
        {
           _dal.Delete(musicId);
        }

        public List<Music> GetAllMusics()
        {
            return _dal.GetMusicsAll();
     
        }

        public Music GetMusicById(int musicId)
        {
            return _dal.GetMusicById(musicId);
        }

        public List<Music> GetMusics()
        {
            return _dal.GetMusics();
        }
    }
}
