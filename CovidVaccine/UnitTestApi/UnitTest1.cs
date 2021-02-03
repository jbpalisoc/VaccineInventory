using CovidVaccine.V2.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestApi
{
    [TestClass]
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllPatient()
        {
            var controller = new PatientsController(new Mock<IMediator>().Object);
            var result = await controller.GetPatients();

            Xunit.Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetPatientExist()
        {
            var controller = new PatientsController(new Mock<IMediator>().Object);
            var actionResult = await controller.GetPatient(61);

            Xunit.Assert.IsType<OkObjectResult>(actionResult.Result);
            //Assert.Equals(61, okResult.Value);
        }
    }
}
