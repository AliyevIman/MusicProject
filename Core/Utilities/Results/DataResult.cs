using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data,bool success,string message):this(success,message)
        {
            this.Data = data;
        }
        public DataResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
        public DataResult(bool success)
        {
            this.Success = success;
        }
        public DataResult(T data, bool success)
        {
            this.Data = data;
            this.Success = success;
        }
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
