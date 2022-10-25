using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class MusiciansMusic :IEntity
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int MusicId { get; set; }
        public virtual Music? Music { get; set; }
    }
}