using System;

namespace CadeOErro.Domain.Exceptions.LogLevel
{
    public class LogLevelNotFoundException : Exception
    {
        public LogLevelNotFoundException(string message = "LogLevel inexistente.") : base(message)
        { }
    }
}
