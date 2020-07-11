using CadeOErro.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CadeOErro.Server.Util.Validators
{
    public class UniqueEmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            var _context = (CadeOErroContext)validationContext.GetService(typeof(CadeOErroContext));
            var entity = _context.Users.Where(e => e.email == value.ToString()).FirstOrDefault();

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"O Email {email} já está em uso.";
        }
    }
}
