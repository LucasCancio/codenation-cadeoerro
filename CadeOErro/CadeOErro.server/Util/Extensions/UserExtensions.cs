using CadeOErro.Domain.Models;

namespace CadeOErro.Server.Util.Extensions
{
    public static class UserExtensions
    {
        public static User FixFields(this User user)
        {
            user.name = user.name.ToFirstLetterUpper();
            user.cpf = user.cpf?.Replace(".", "").Replace("-", "");
            user.password = MD5Cryptography.GetHash(user.password);

            return user;
        }
    }
}
