using Entites.Concrete;
using Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthManager
    {
        void Register(RegisterUserDTO model);
        User GetUserByEmail(string email);
        User Login(string email);
        List<User> GetUsers();
    }
}
