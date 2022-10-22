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
    public class RefreshTokenManager : IRefreshTokenManager
    {
        private readonly IRefreshTokensDal _dal;

        public RefreshTokenManager(IRefreshTokensDal dal)
        {
            _dal = dal;
        }

        public Task<IEnumerable<RefreshToken>> GetAll()
        {
            return _dal.GetAll();
        }
    }
}
