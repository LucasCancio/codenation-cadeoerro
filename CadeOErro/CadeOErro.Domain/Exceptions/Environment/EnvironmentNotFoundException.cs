using System;

namespace CadeOErro.Domain.Exceptions.Environment
{
    public class EnvironmentNotFoundException : Exception
    {
        public EnvironmentNotFoundException(string message = "Ambiente inexistente.") : base(message)
        { }
    }
}
