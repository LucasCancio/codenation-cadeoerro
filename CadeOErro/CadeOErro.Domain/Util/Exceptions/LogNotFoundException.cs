using System;

namespace CadeOErro.Domain.Util.Exceptions
{
    public class LogNotFoundException : Exception
    {
        public LogNotFoundException(string message = "Log inexistente") : base(message)
        { }
    }
}
