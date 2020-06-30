using System;

namespace CadeOErro.Server.Util.Exceptions
{
    public class EnvironmentNotFoundException : Exception
    {
        public EnvironmentNotFoundException(string message = "Ambiente inexistente") : base(message)
        { }
    }
}
