using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.Util.Validatons
{
    public class RoleValidation 
    {
        public static bool IsRole(string role)
        {
            role = role.ToLower();
            return (role != "admin" && role != "user");
        }
    }
}
