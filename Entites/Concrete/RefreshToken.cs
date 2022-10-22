using Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class RefreshToken :IEntity
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string jwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRoveked { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime AddedTime { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }



    }
}
