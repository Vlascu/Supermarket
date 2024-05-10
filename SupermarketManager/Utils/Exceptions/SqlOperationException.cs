using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils.Exceptions
{
    public class SqlOperationException : Exception
    {
        public SqlOperationException(string message) : base(message) { }
      
    }
}
