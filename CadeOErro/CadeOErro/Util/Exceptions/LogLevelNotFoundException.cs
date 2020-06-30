using System;

namespace CadeOErro.Server.Util.Exceptions
{
    public class LogLevelNotFoundException : Exception
    {
        public LogLevelNotFoundException(string message = "LogLevel inexistente") : base(message)
        { }
    }
}
