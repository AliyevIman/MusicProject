﻿using Core;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal :IEntityRepository<Order>
    {
        List<Order> GetAllOrders();
        List<Order> GetOrderByUser(string userId);
    }
}