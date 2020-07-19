using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace CadeOErro.Domain.Exceptions.User
{
    public class InvalidUserException : Exception
    {
        public ValidationResult ValidationResult { get; private set; }
        public InvalidUserException(ValidationResult result, string message = "Usuário inválido.") : base(message)
        {
            this.ValidationResult = result;
        }
    }
}
