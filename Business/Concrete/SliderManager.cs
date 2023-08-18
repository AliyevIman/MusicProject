using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Migrations;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SliderManager : ISliderManager
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Creat(Slider slider)
        {
            _sliderDal.Add(slider);
        }

        public void DeleteSlider(int id)
        {
            var getMusic = _sliderDal.Get(c => c.Id == id && !c.IsDeleted);
            if (getMusic != null)
            {
                getMusic.IsDeleted = true;
                _sliderDal.Update(getMusic);
            }
        }

        public List<Slider> GetAll()
        {
           return _sliderDal.GetAll();
        }

        public async  Task<Slider> Get()
        {
            return  _sliderDal.Get(c =>!c.IsDeleted);
        }

        public void Update(Slider slider)
        {
            _sliderDal.Update(slider);
        }

        public Slider GetById(int? id)
        {
            return _sliderDal.Get(c => c.Id==id &&!c.IsDeleted);

        }
    }
}
