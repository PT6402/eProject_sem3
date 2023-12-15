using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Dto
{
    public class DtoResult<T>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Model { get; set; }
    }
}
