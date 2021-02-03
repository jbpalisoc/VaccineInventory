using CovidVaccine.Handlers;
using CovidVaccine.Model;
using CovidVaccine.Queries;
using CovidVaccine.V2.Controllers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiUnitTest
{
    [TestClass]
    public class TestPatientController
    {

        IRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IRepository>().Object;           
        }


        [Fact]
        public async Task GetAllProducts_ShouldReturnAllProducts()
        {

            var result = await _repository.SelectById<Patient>(61);

            //var result equa= handler as IEnumerable<Patient>;
            NUnit.Framework.Assert.Equals(61, result.Id);
        }



        /*        [TestMethod]
                public async Task GetAllProductsAsync_ShouldReturnAllProducts()
                {
                    var testProducts = GetTestProducts();
                    var controller = new SimpleProductController(testProducts);

                    var result = await controller.GetAllProductsAsync() as IEnumerable<Patient>;
                    Assert.AreEqual(testProducts.Count, result.Count);
                }

                [TestMethod]
                public void GetProduct_ShouldReturnCorrectProduct()
                {
                    var testProducts = GetTestProducts();
                    var controller = new SimpleProductController(testProducts);

                    var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
                    Assert.IsNotNull(result);
                    Assert.AreEqual(testProducts[3].Name, result.Content.Name);
                }

                [TestMethod]
                public async Task GetProductAsync_ShouldReturnCorrectProduct()
                {
                    var testProducts = GetTestProducts();
                    var controller = new SimpleProductController(testProducts);

                    var result = await controller.GetProductAsync(4) as OkNegotiatedContentResult<Product>;
                    Assert.IsNotNull(result);
                    Assert.AreEqual(testProducts[3].Name, result.Content.Name);
                }

                [TestMethod]
                public void GetProduct_ShouldNotFindProduct()
                {
                    var controller = new SimpleProductController(GetTestProducts());

                    var result = controller.GetProduct(999);
                    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
                }*/


    }
}
