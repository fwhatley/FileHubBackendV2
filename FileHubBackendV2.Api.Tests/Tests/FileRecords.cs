using FileHubBackendV2.Api.Tests.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Tests
{
    [TestFixture]
    public class FileRecordsTests
    {
        private readonly string _baseUrl = "http://localhost:80";

        [Test]
        public async Task GetFileRecord_ShouldReturnOk()
        {
            // ARRANGE - set up test dependent data and state
            var fileRecord = new FileRecord
            {
                Name = "mySampleFile.jpg",
                Description = "This is a description",
                Tags = "tag1, tag2",
                Url = "sampleUrl.com"
            };

            var response = new HttpResponseMessage();

            try
            {
                // ACT - perform test action
                response = await CreateFileRecord(fileRecord);

                // ASSERT - verify test results 
                var fileRecordReturned = await response.Content.ReadAsAsync<FileRecord>();
                fileRecordReturned.Name.Should().Be(fileRecord.Name);
                fileRecordReturned.Description.Should().Be(fileRecord.Description);
                fileRecordReturned.Url.Should().Be(fileRecord.Url);
                fileRecordReturned.Tags.Should().Be(fileRecord.Tags);

                // clean up
            }
            catch (Exception)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }

        }

        [Test]
        public async Task GetFileRecords_ShouldReturnOk()
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/fileRecords/";
            var httpClient = new HttpClient();

            var fileRecord = new FileRecord
            {
                Name = "mySampleFile.jpg",
                Description = "This is a description",
                Tags = "tag1, tag2",
                Url = "sampleUrl.com"
            };

            var response = new HttpResponseMessage();

            try
            {

                response = await CreateFileRecord(fileRecord);
                response.StatusCode.Should().Be(HttpStatusCode.OK, "because I just posted a fileRecord");

                // ACT - perform test action
                response = await httpClient.GetAsync(url);

                // ASSERT - verify test results 
                response.StatusCode.Should().Be(HttpStatusCode.OK, "because I posted and retrieved all fileRecords");

                // clean up
            }
            catch (Exception)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }
        }

        [Test]
        public async Task GetFileRecord_ShouldReturnNotFound()
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/fileRecords/";
            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();

            try
            {
                // ACT - perform test action
                response = await httpClient.GetAsync(url + Guid.NewGuid());

                // ASSERT - verify test results
                response.StatusCode.Should().Be(HttpStatusCode.NotFound, "because I just made up the guid");

                // Clean up

            }
            catch (Exception)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }
        }

        [Test]
        public async Task PostFileRecord_ShouldReturnOk()
        {
            // ARRANGE - set up test dependent data and state
            var fileRecord = new FileRecord
            {
                Name = "mySampleFile.jpg",
                Description = "This is a description",
                Tags = "tag1, tag2",
                Url = "sampleUrl.com"
            };

            var response = new HttpResponseMessage();

            try
            {
                // ACT - perform test action
                response = await CreateFileRecord(fileRecord);

                // ASSERT - verify test results 
                response.StatusCode.Should().Be(HttpStatusCode.OK, "because I just posted a fileRecord");
                var fileRecordReturned = await response.Content.ReadAsAsync<FileRecord>();
                fileRecordReturned.Name.Should().Be(fileRecord.Name);

                // clean up
            }
            catch (Exception)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }

        }

        [Test]
        public async Task PostFileRecord_WithoutFileName_ShouldReturnBadRequest()
        {
            // ARRANGE - set up test dependent data and state
            var fileRecord = new FileRecord
            {
                Name = "",
                Description = "This is a description",
                Tags = "tag1, tag2",
                Url = "sampleUrl.com"
            };

            var response = new HttpResponseMessage();

            try
            {
                // ACT - perform test action
                response = await CreateFileRecord(fileRecord);

                // ASSERT - verify test results 
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest, "because filename is required");

                // clean up
            }
            catch (Exception)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }

        }

        #region Helpers
        private async Task<HttpResponseMessage> CreateFileRecord(FileRecord fileRecord)
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/fileRecords";

            var client = new HttpClient();

            // ACT - perform test action
            // tips: https://stackoverflow.com/questions/10304863/how-to-use-system-net-httpclient-to-post-a-complex-type
            var response = await client.PostAsJsonAsync(url, fileRecord);
            return response;

        }
        #endregion

    }
}
