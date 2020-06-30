using System;

namespace CadeOErro.Domain.Util.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "Usuário inexistente") : base(message)
        { }
    }
}
