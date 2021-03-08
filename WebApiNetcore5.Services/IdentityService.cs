using Microsoft.AspNetCore.Identity;

namespace WebApiNetcore5.Services
{
    
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;


    }
}
