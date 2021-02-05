using CovidVaccine.Commands;
using CovidVaccine.Model;
using CovidVaccine.V2.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestApi
{
    public class PatientUnitTest
    {
        PatientsController _controller;
        public PatientUnitTest()
        {
            _controller = new PatientsController(new Mock<IMediator>().Object);
        }
        [Fact]
        public async Task GetOkAllPatient()
        {
            var result = await _controller.GetPatients();
            //var okResult = Assert.IsType<ActionResult<IEnumerable<Patient>>>(result.Result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetOkPatient()
        {
            var controller = new PatientsController(new Mock<IMediator>().Object);
            var result = await controller.GetPatient(61);

            Assert.IsType<OkResult>(result.Result);
            //Assert.Equal(61, result.Value.Id);
        }

        [Fact]
        public async Task GetPatientNotFound()
        {
            var result = await _controller.GetPatient(61);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostPatient()
        {
            var repo = new Mock<IMediator>().Object;
            PostPatientCommand commad = new PostPatientCommand()
            {
                Id = 0,
                FirstName = "Jason",
                MiddleName = "Brace",
                LastName = "Palisoc",
                ContactNo = "09662679535",
                Birthday = new DateTime(),
                Sex = 'M'

            };
            var result = await _controller.PostPatient(commad);

            Assert.IsType<OkResult>(result.Result);
        }
    }
}
