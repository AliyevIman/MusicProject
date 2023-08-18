using Core.Utilities.Results;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface  ISliderManager
    {
        List<Slider> GetAll();
        void Creat(Slider slider);
        void DeleteSlider(int id);
        Task<Slider > Get();
        Slider GetById(int? id);
        void Update(Slider slider);
    }
}
