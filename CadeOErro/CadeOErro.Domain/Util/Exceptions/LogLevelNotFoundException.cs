using System;

namespace CadeOErro.Domain.Util.Exceptions
{
    public class LogLevelNotFoundException : Exception
    {
        public LogLevelNotFoundException(string message = "LogLevel inexistente") : base(message)
        { }
    }
}
