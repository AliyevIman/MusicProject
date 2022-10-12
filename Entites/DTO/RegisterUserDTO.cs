using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class RegisterUserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; }= null!;
        public string Password { get; set; } = null!;
        //[Compare("Password", 
        //    ErrorMessage = "Password and confirmation password not match.")]
        //public string ConfirmPassword { get; set; }=null!;
    } 
}