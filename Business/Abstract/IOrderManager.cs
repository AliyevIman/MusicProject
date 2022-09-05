using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderManager
    {
        List<Order> GetAll();
        List<Order> GetOrderBYUser(string userId);    
    }
}