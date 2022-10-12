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
    public class EfTicketDal : EfEntityRepositoryBase<MusicDbContext, Ticket>, ITicketDal
    {
        public async Task<Ticket> GetById(int id)
        {
            using MusicDbContext context = new();
            return await context.Tickets.FirstOrDefaultAsync(t => t.Id == id); 
        }
    }
}