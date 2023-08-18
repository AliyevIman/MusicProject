using Core;
using Core.Utilities.Results;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISliderDal:IEntityRepository<Slider>
    {
        Slider GetSlider();
    }
}