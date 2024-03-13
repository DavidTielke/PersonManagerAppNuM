using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Exceptions;

namespace Backend.Data.DatabaseStorage
{
    public class DatabaseStorageException : NuMBaseException
    {
        public DatabaseStorageException()
        {
        }

        public DatabaseStorageException(string message, string domainMessage) : base(message, domainMessage)
        {
        }

        public DatabaseStorageException(string message, string domainMessage, Exception inner) : base(message, domainMessage, inner)
        {
        }
    }
}
