using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPiNetcore5;
using Xunit;

namespace WebApiNetcore5.IntegrationTest
{
    public class UnitTest1
    {
        private readonly HttpClient _client;

        public UnitTest1()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
        [Fact]
        public async Task Test1()
        {
            //I HATE MAGIC STRINGS!!!
            var response = await _client.GetAsync("http://localhost:5000/api/v1/todos");
        }
    }
}
