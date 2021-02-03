using CovidVaccine.V2.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiTest
{
    public class TestPatientController
    {
        PatientsController _controller;
        public TestPatientController()
        {
            _controller = new PatientsController(new Mock<IMediator>().Object);
        }

        [Fact]
        public async Task GetAllPatient()
        {
            var result = await _controller.GetPatients();

            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetPatientExist()
        {
            var actionResult = await _controller.GetPatient(61);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            //Assert.Equals(61, okResult.Value);
        }

    }
}
