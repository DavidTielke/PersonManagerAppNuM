using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Proxies.ExceptionMapping
{
    public class ExceptionMap : Attribute
    {
        public Type ExceptionType { get; set; }

        public ExceptionMap(Type exceptionType)
        {
            ExceptionType = exceptionType;
        }
    }
}
