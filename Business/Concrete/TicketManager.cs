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
    public class TicketManager : ITicketManager
    {
        private readonly ITicketDal _dal;

        public TicketManager(ITicketDal dal)
        {
            _dal = dal;
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _dal.GetById(id);
        }
    }
}
