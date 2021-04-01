using System.Threading.Tasks;
using WebApiNetcore5.Model;

namespace WebAPiNetcore5.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string Email, string Password);

        Task<AuthenticationResult> LoginAsync(string Email, string Password);

    }
}
