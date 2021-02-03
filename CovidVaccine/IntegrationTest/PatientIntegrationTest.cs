using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class PatientIntegrationTest
    {
        private HttpClient Client;

        public PatientIntegrationTest(HttpClient client)
        {
            Client = client;
        }

        [Fact]
        public async Task GetPatientsAsync()
        {
            // Arrange
            var request = "/api/v2/Patients";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
