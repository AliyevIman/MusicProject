using Business.Abstract;
using Core.Security.Hasing;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager:IAuthManager
    {
        private readonly IAuthDal _authDal;
        private readonly IUserRoleManager _userRoleManager;
        private readonly HashingHandler _hashingHandler;
        public AuthManager(IAuthDal authDal, HashingHandler hashingHandler, IUserRoleManager userRoleManager)
        {
            _authDal = authDal;
            _hashingHandler = hashingHandler;
            _userRoleManager = userRoleManager;
        }

        public User Login(string email)
        {
            var user = _authDal.Get(x => x.Email == email);
            if (user == null)
                return null;

            return user;
        }

        public List<User> GetUsers()
        {
            return _authDal.GetAll();
        }

        public void Register(RegisterUserDTO model)
        {
            User user = new()
            {
                Email = model.Email,
                FullName = model.FullName,
                Password = _hashingHandler.PasswordHash(model.Password),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            };
            _authDal.Add(user);
            var currentUser = _authDal.Get(x => x.Email == user.Email);
            _userRoleManager.AddDefaultRole(currentUser.Id);

        }

        public User GetUserByEmail(string email)
        {
            return _authDal.Get(x => x.Email == email);
        }
    }
}
