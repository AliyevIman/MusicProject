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
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDal _dal;

        public OrderManager(IOrderDal dal)
        {
            _dal = dal;
        }

        public List<Order> GetAll()
        {
            return _dal.GetAllOrders();
        }

        public List<Order> GetOrderBYUser(string userId)
        {
            return _dal.GetOrderByUser(userId);
        }
    }
}