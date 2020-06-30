using System;

namespace CadeOErro.Server.Util.Exceptions
{
    public class LogNotFoundException : Exception
    {
        public LogNotFoundException(string message = "Log inexistente") : base(message)
        { }
    }
}
