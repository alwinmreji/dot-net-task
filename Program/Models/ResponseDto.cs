using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    public class ResponseDto
    {
        public string Message { get; set; }
        public long Count { get; set; }
        public object? Data { get; set; }
    }
}
