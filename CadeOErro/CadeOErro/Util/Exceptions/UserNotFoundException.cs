using System;

namespace CadeOErro.Server.Util.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string? message) : base(message)
        { }
    }
}
