using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class User :IdentityUser
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
    }
}
