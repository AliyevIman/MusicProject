using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Slider :IEntity
    {
        public int Id { get; set; }
        public string? Header { get; set; }
        public string? SubHeader{ get; set; }
        public string? Picture1 { get; set; }
        public string? Picture2 { get; set; }
        public string? Picture3 { get; set; }
        public bool IsDeleted { get; set; }

    }
}
