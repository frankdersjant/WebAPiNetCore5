using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPiNetcore5.Installers;
using WebAPiNetcore5.Options;

namespace WebAPiNetcore5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallerOfServicesInAssembly(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SwaggerOptions swaggeroptions; 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                ////Swagger - note new usings
                app.UseSwagger();

                swaggeroptions = new SwaggerOptions();
                Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggeroptions);

                app.UseSwagger(option =>
                {
                    option.RouteTemplate = swaggeroptions.JsonRoute;
                });

                app.UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint(swaggeroptions.UiEndpoint, swaggeroptions.Description);
                });
                //end swagger

            }
            else
            {
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
