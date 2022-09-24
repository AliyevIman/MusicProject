using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;
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

        public void DeleteMusic(int musicId)
        {
            var getMusic =  _dal.Get(c=>c.Id==musicId&&!c.IsDeleted);
            if (getMusic !=null)
            {
                getMusic.IsDeleted = true;
                _dal.Update(getMusic);
            }
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

        public void Udpdate(int id, Music music)
        {
            _dal.UpdateMusic(id, music);
        }
    }
}
