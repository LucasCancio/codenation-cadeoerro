using CadeOErro.Server.DTOs.Login;
using CadeOErro.Server.DTOs.User;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface ILoginService
    {
        AuthenticateDTO Authenticate(string email, string password);
        UserViewDTO ChangePassword(PasswordDTO dto);
    }
}
