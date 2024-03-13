using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Exceptions;

namespace Backend.Logic.PersonManagement
{
    public class PersonManagementException : NuMBaseException
    {
        public PersonManagementException()
        {
        }

        public PersonManagementException(string message, string domainMessage) : base(message, domainMessage)
        {
        }

        public PersonManagementException(string message, string domainMessage, Exception inner) : base(message, domainMessage, inner)
        {
        }
    }
}
