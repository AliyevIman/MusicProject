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
    public class EfRoleDal : EfEntityRepositoryBase<MusicDbContext, Role>, IRoleDal
    {
        public Role GetUserRole(int userId)
        {

            using MusicDbContext context = new();
            
            var roleUser = context.UserRole.Include(x =>x.Role).FirstOrDefault(x => x.UserId == userId);

            var role = new Role()
            {
                Id = roleUser.RoleId,
                Name = roleUser.Role.Name
            };

            return role;
        }
    }
}
