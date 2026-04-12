using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesti.Core.Result
{
    public class StringResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public StringResult(bool result, string message)
        {
            Result = result; Message = message;
        }
    }
}
