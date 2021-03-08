using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebAPiNetcore5.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallerOfServicesInAssembly(this IServiceCollection services, IConfiguration Configuration)
        {
            var Installers = typeof(Startup).Assembly.ExportedTypes.
                Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                Select(Activator.CreateInstance).
                Cast<IInstaller>().ToList();

            Installers.ForEach(installer => installer.InstallService(services, Configuration));

        }
    }
}
