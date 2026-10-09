using Microsoft.AspNetCore.Mvc.Testing;
namespace Apiunittesting
{
    public class UnitTest1
    {
        WebApplicationFactory<Program> factory;
        HttpClient client;
        public UnitTest1()
        {
            factory = new WebApplicationFactory<Program>();
            client = factory.CreateClient();
        }


        [Fact]
        public async Task FirstApiTest()
        {
            var response = await client.GetAsync("api/first");
            int statuscode = (int)response.StatusCode;
            Assert.Equal(200, statuscode);
        }
        [Theory]
        [InlineData(5, 25)]
        [InlineData(10,100)]
        [InlineData(2,5)]
        public async Task SecondApiTest(int a,int expected)
        {
            var response = await client.PostAsync("api/square/" + a, null);
            int result = Convert.ToInt32(await response.Content.ReadAsStringAsync());
            Assert.Equal(expected, result);
        }
    }
}
