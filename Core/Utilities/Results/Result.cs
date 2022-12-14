using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success,string message)
        {
            this.Success = success;
            this.Message = message;
        }
        public Result(bool success)
        {
            this.Success=success;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
