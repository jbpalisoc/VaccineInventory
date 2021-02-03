using CovidVaccine;
using CovidVaccine.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class TestPatient : IClassFixture<CustomFactory<Startup>>
    {
        // HttpClient Client;
        private CustomFactory<Startup> _server;
        private HttpClient _client;

        public TestPatient(CustomFactory<Startup> server)
        {
            _server = server;
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestGetPatientAsync()
        {
            // Arrange
            var request = "/api/v2/Patients";

            // Act
            var response = await _client.GetAsync(request);
            var stringResponse = response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<List<Patient>>(stringResponse.Result);
            // Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(0 < patient.Count);
        }
        [Fact]
        public async Task TestGetPatientByIdAsync()
        {
            // Arrange
            var request = "/api/v2/Patients/1";

            // Act
            var response = await _client.GetAsync(request);
            var stringResponse = response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<Patient>(stringResponse.Result);
            // Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(1, patient.Id);
        }

        [Fact]
        public async Task TestGetPatientByIdNotFoundAsync()
        {
            // Arrange
            var request = "/api/v2/Patients/111";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task TestPostPatientAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v2/Patients/",
                Body = new {
                                id = 0,
                                firstName = "Jason",
                                middleName = "Brace",
                                lastName = "Palisoc",
                                contactNo = "string",
                                birthday = "2021-02-02T08:10:22.269Z",
                                sex = 'M'
                            }
            };

            // Act
            var response = await _client.PostAsync(request.Url, 
                new StringContent(JsonConvert.SerializeObject(request.Body), Encoding.Default, "application/json"));
            var stringResponse = response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<Patient>(stringResponse.Result);

            // Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(0 < patient.Id);
        }
        [Fact]
        public async Task TestPutPatientAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v2/Patients/1",
                Body = new
                {
                    id = 1,
                    firstName = "Jason",
                    middleName = "Brace",
                    lastName = "Palisoc",
                    contactNo = "string",
                    birthday = "2021-02-02T08:10:22.269Z",
                    sex = 'M'
                }
            };

            // Act
            var response = await _client.PutAsync(request.Url,
                new StringContent(JsonConvert.SerializeObject(request.Body), Encoding.Default, "application/json"));
            var stringResponse = response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<Patient>(stringResponse.Result);

            // Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(1, patient.Id);
        }
       /*[Fact]
        public async Task TestDeletePatientAsync()
        {
            // Arrange
            var request = "/api/v2/Patients/61";
            
            // Act
            var response = await _client.DeleteAsync(request);
            var stringResponse = response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<Patient>(stringResponse.Result);

            // Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(61, patient.Id);
        }*/
    }
}
