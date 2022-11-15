using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTO
{
    public class EditMusicianDTO
    {

        public string? Firstname { get; set; }
        public string? Lastname { get; set; } 

        public string? Biography { get; set; }
        public string? Photo { get; set; }
        [ConcurrencyCheck]
        public string? Email { get; set; }
    }
}
