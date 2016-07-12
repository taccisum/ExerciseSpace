using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerException
{
    public class CommonException : ApplicationException
    {
        public string ErrorMsg { get; private set; }
        public object Data { get; private set; }

        public CommonException(string msg)
        {
            ErrorMsg = msg;
        }

        public CommonException(string msg, object data)
        {
            ErrorMsg = msg;
            Data = data;
        }
    }
}
