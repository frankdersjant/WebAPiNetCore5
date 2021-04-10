using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApiNetcore5.DAL;
using WebAPiNetcore5;
using WebAPiNetcore5.Controllers.V1.Request;
using WebAPiNetcore5.Controllers.V1.Response;

namespace WebApiNetcore5.IntegrationTest
{
    public class BaseClassIntegrationTest
    {
        protected readonly HttpClient _client;

        public BaseClassIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DataContext));
                        services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "testdbinmemory"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
                        services.AddDbContext<DataContext>(options =>
                        {
                            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "testdbinmemory"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
                        });
                    });
                });

            _client = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var response = await _client.PostAsJsonAsync("http://localhost:5000/api/v1/Identity/Register", new UserRegistrationRequest
            {
                Email = "integration@test.com",
                Password = "Frank1234!"
            });

            var RegistrationResponse = await response.Content.ReadAsAsync<AuthSuccesResponse>();

            return RegistrationResponse.Token;
        }
    }
}
