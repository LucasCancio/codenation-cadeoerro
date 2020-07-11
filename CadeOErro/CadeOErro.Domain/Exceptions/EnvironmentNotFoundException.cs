using System;

namespace CadeOErro.Domain.Util.Exceptions
{
    public class EnvironmentNotFoundException : Exception
    {
        public EnvironmentNotFoundException(string message = "Ambiente inexistente") : base(message)
        { }
    }
}
