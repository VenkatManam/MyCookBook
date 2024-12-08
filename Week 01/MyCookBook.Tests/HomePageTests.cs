using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MyCookBook.Tests
{
    public class HomePageTests : TestBase, IClassFixture<WebApplicationFactory<MyCookBook.Program>>
    {
        private readonly HttpClient _client;

        public HomePageTests(WebApplicationFactory<MyCookBook.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task HomePage_ShouldReturnSuccessAndContainHeading()
        {
            await ExecuteTestAsync("HomePage_ShouldReturnSuccessAndContainHeading", async () =>
            {
                var response = await _client.GetAsync("/Home/HomePage");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Assert.Contains("<h1>Welcome to My Cook Book</h1>", content);
            });
        }

        [Fact]
        public async Task HomePage_ShouldContainParagraph()
        {
            await ExecuteTestAsync("HomePage_ShouldContainParagraph", async () =>
            {
                var response = await _client.GetAsync("/Home/HomePage");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                Assert.Contains("<p>Your personalized recipe manager is under development.</p>", content);
            });
        }
    }
}
