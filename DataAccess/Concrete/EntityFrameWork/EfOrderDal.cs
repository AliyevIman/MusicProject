using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfOrderDal : IEntityRepository<MusicDbContext, Order>, IOrderDal
    {
        public List<Order> GetAllOrders()
        {
            using MusicDbContext _context = new();
            return _context.Orders.Include(c=>c.Ticket).ToList();
        }

        public List<Order> GetOrderByUser(string userId)
        {
            using MusicDbContext _context = new();

            return _context.Orders.Include(c => c.Ticket).Where(s=>s.UserId==userId).ToList();
        }
    }
}