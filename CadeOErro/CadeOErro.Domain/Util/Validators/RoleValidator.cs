using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Domain.Util.Validators
{
    public class RoleValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            return RoleValidator.IsRole(value.ToString());
        }

        private static bool IsRole(string role)
        {
            role = role.ToLower();
            return (role != "admin" || role != "user");
        }
    }
}
