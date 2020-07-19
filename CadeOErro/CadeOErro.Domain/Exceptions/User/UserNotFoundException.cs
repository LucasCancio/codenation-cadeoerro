using System;

namespace CadeOErro.Domain.Exceptions.User
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "Usuário inexistente.") : base(message)
        { }
    }
}
