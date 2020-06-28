using CadeOErro.Server.DTOs.Login;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface ILoginService
    {
       Task<AuthenticateDTO> Authenticate(string email, string password);
    }
}
