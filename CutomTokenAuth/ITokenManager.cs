using CutomTokenAuth.Models;
using System.Threading.Tasks;

namespace CutomTokenAuth
{
    public interface ITokenManager
    {
        Task<bool> Authenticate(string userName, string password);
        Task<Token> CreateToken();
        Task<bool> VerifyToken(string token);
    }
}