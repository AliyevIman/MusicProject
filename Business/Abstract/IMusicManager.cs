using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMusicManager
    {
        List<Music> GetMusics();
        List<Music> GetAllMusics();
        void AddMusic(Music music);
        Music GetMusicById(int musicId);
        void DeleteMusic(int musicId);
        void Udpdate(int id, Music music);
    }
}