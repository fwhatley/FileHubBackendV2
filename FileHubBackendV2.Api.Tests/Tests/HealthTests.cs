using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Tests
{
    [TestFixture]
    public class HealthTests
    {
        private readonly string _baseUrl = "http://localhost:80";

        [Test]
        public async Task GetFile_ShouldReturnOk()
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/health";
            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();

            try
            {
                // ACT - perform test action
                response = await httpClient.GetAsync(url);

                // ASSERT - verify test results
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                // Clean up

            }
            catch (Exception)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }
        }
    }
}
