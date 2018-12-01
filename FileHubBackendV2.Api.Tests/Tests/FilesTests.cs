using FileHubBackendV2.Api.Tests.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
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
        private readonly string _baseUrl = "http://localhost:5000";

        [Test]
        public async Task GetFiles_ShouldReturnOk()
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/files";
            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();

            try
            {
                // creating a file
                var fhFileToPost = new FhFile
                {
                    Name = "mySampleFile.jpg",
                };
                await Create_File(fhFileToPost);

                // ACT - perform test action
                response = await httpClient.GetAsync(url);
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                // ASSERT - verify test results
                var fhFileReturned = await response.Content.ReadAsAsync<List<FhFile>>();
                fhFileReturned.Count.Should().BeGreaterThan(0, "because I added a file");

                // Clean up

            }
            catch (Exception e)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }

        }

        [Test]
        public async Task GetFile_ShouldReturnOk()
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/files/";
            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();

            try
            {
                // creating a file
                var fhFileToPost = new FhFile
                {
                    Name = "mySampleFile.jpg",
                };
                var createdFileResponse = await Create_File(fhFileToPost);
                createdFileResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                var createdFile = await createdFileResponse.Content.ReadAsAsync<FhFile>();


                // ACT - perform test action
                response = await httpClient.GetAsync(url + createdFile.Id);
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                // ASSERT - verify test results
                var fhFileReturned = await response.Content.ReadAsAsync<FhFile>();
                fhFileReturned.Name.Should().Be(fhFileToPost.Name, "because I created a file with that fileName");

                // Clean up

            }
            catch (Exception e)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }
        }

        [Test]
        public async Task GetFile_ShouldReturnNotFound()
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/files/";
            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();

            try
            {
                // ACT - perform test action
                response = await httpClient.GetAsync(url + new Guid());

                // ASSERT - verify test results
                response.StatusCode.Should().Be(HttpStatusCode.NotFound, "because I just made up the guid");

                // Clean up

            }
            catch (Exception e)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }
        }

        [Test]
        public async Task PostFile_ShouldReturnOk()
        {
            // ARRANGE - set up test dependent data and state
            var fhFileToPost = new FhFile
            {
                Name = "mySampleFile.jpg",
            };

            var response = new HttpResponseMessage();

            try
            {
                // ACT - perform test action
                response = await Create_File(fhFileToPost);

                // ASSERT - verify test results 
                var fhFileReturned = await response.Content.ReadAsAsync<FhFile>();
                fhFileReturned.Name.Should().Be(fhFileToPost.Name);

                // clean up
            }
            catch (Exception e)
            {
                Console.WriteLine("Response content:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw;
            }


        }

        #region Helpers
        private async Task<HttpResponseMessage> Create_File(FhFile fhFile)
        {
            // ARRANGE - set up test dependent data and state
            var url = $"{_baseUrl}/api/files";
            var imageInBytes = File.ReadAllBytes("./InputTestFiles/fileName1.jpg"); // ./ instead of ../ because tests are run from root folder in debug or release mode

            // set up content to upload
            HttpContent fileName = new StringContent(fhFile.Name);
            HttpContent fileRecord = new StringContent(fhFile.FileRecordId.ToString());
            HttpContent file = new StreamContent(new MemoryStream(imageInBytes));


            var client = new HttpClient();
            var content = new MultipartFormDataContent("Upload----" + System.DateTime.Now.ToString(CultureInfo.InvariantCulture));
            content.Add(fileName, "fileName"); // fileName & fileRecord are the formData fields. fileName is required
            content.Add(fileRecord, "fileRecord");
            content.Add(file, "file", "dummyfileName.jpg");

            // ACT - perform test action
            var response = await client.PostAsync(url, content);
            return response;

        }
        #endregion

    }
}