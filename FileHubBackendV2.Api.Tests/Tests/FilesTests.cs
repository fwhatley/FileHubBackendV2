using FileHubBackendV2.Api.Tests.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Tests
{
    [TestFixture]
    public class FilesTests
    {
        private readonly string baseUrl = "http://localhost:5000";

        [Test]
        public async Task GetFiles_ShouldReturnOk()
        {
            var url = $"{baseUrl}/api/files";
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);
            var fhFile = await response.Content.ReadAsAsync<List<FhFile>>();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Test]
        public async Task PostFile_ShouldReturnOk()
        {
            var url = $"{baseUrl}/api/files";
            var imageInBytes = File.ReadAllBytes("./InputTestFiles/fileName1.jpg"); // ./ instead of ../ because tests are run from root folder in debug or release mode

            // set up conten to upload
            HttpContent fileName = new StringContent("fileName"); 
            HttpContent fileRecord = new StringContent("fileRecord"); 
            HttpContent file = new StreamContent(new MemoryStream(imageInBytes));


            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent("Upload----" + System.DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    content.Add(fileName, "fileName");
                    content.Add(fileRecord, "fileRecord");
                    content.Add(file, "file", "dummyfileName.jpg");

                    using (var message = await client.PostAsync(url, content))
                    {
                        var input = await message.Content.ReadAsStringAsync();

                        message.StatusCode.Should().Be(HttpStatusCode.OK);

                    }
                }
            }

        }
    }
}