using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class MusicianListDTO
    {
        public string Firstname { get; set; } = null!;
        public string Biography { get; set; }
        public string Photo { get; set; }
        public bool IsNew { get; set; }
    }
}