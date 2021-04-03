using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApiNetcore5.DAL;
using WebAPiNetcore5;
using Xunit;

namespace WebApiNetcore5.IntegrationTest
{
    public class BaseClassIntegrationTest
    {
        private readonly HttpClient _client;

        public BaseClassIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DataContext));
                        services.AddDbContext<DataContext>(options =>
                        {
                            options.UseInMemoryDatabase("testdb");
                        });
                    });
                };

            _client = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {

            throw new NotImplementedException();
        }

        [Fact]
        public async Task Test1()
        {
            //I HATE MAGIC STRINGS!!!
            var response = await _client.GetAsync("http://localhost:5000/api/v1/todos");
        }
    }
}
