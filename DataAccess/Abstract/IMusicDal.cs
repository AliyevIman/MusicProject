using Core;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMusicDal :IEntityRepository<Music>
    {
        List<Music> GetMusics();

        List<Music> GetMusicsAll();
        void Create(Music music);
        Music GetMusicById(int? musicId);
        void Delete(int musicId);

        //Music GetFeatureMusic();
    }
}