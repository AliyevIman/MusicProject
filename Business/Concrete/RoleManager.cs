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
    public class RoleManager : IRoleManager
    {
        private readonly IRoleDal _dal;

        public RoleManager(IRoleDal dal)
        {
            _dal = dal;
        }

        public Role GetRole(int userId)
        {
            return _dal.GetUserRole(userId);    
        }
    }
}
