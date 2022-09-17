using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShoppingCart.UnitTest
{
    public class ProductControllerTest
    {
        private readonly ProductController _controller;
        private readonly IProductService _service;

        public ProductControllerTest()
        {
            _service = new ProductServiceFake();
            _controller = new ProductController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllProductsList();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()  //fake service içerisindeki liste deðer sayýsýný getir
        {
            // Act
            var okResult = _controller.GetAllProductsList() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetProduct(12232);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 100;

            // Act
            var okResult = _controller.GetProduct(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId= 101;

            // Act
            var okResult = _controller.GetProduct(testId) as OkObjectResult;

            // Assert
            Assert.IsType<Product>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Product).ProductId);
        }


        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId= 1234;

            // Act
            var badResponse = _controller.DeleteProductFromCart(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
     

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 100;

            // Act
            var okResponse = _controller.DeleteProductFromCart(existingId);

            // Assert
            Assert.Equal(2, _service.TGetList().Count());
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOneItem()
        {
            // Arrange
            var existingId = 100;
            var otherId = 101;

            // Act
            var okResponse = _controller.DeleteProductFromCart(existingId);
            var okResponse1 = _controller.DeleteProductFromCart(otherId);

            // Assert
            Assert.Equal(1, _service.TGetList().Count());
        }
    }
}
