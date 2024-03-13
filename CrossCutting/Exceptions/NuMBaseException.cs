using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Exceptions
{
    public class NuMBaseException : Exception
    {
        public string DomainMessage { get; set; }

        public NuMBaseException()
        {
        }

        public NuMBaseException(string message, string domainMessage) : base(message)
        {
            DomainMessage = domainMessage;
        }

        public NuMBaseException(string message, string domainMessage, Exception inner) : base(message,  inner)
        {
            DomainMessage = domainMessage;
        }
    }
}
