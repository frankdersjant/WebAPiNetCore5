using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiNetcore5.Model;
using Xunit;

namespace WebApiNetcore5.IntegrationTest
{
    public class TodosControllerTest : BaseClassIntegrationTest
    {
        [Fact]
        public async Task GetAll_Should_Return_All_ToDos()
        {
            //arrange
            await AuthenticateAsync();

            //act
            var response = await _client.GetAsync("http://localhost:5000/api/v1/todos/GetTodos");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<Todos>()).Should().NotBeNull();

        }
    }
}
