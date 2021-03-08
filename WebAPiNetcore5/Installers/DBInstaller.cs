using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPiNetcore5.Installers
{
    public class DBInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Data._DbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Data._DbContext>();
            services.AddControllersWithViews();
        }
    }
}
