using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShopBridge.Controllers;
using ShopBridge.Infrastrusture.Interfaces;
using ShopBridge.Infrastrusture.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge.Products.UnitTest
{
    public class ProductsUnitTests
    {
        private readonly Mock<IProducts> _ProductServiceMock;
        private readonly Mock<ILogger<ProductsController>> _loggerMock;

        public ProductsUnitTests()
        {
            _ProductServiceMock = new Mock<IProducts>();
            _loggerMock = new Mock<ILogger<ProductsController>>();
        }

        [Fact]
        public async Task GetProductDetails_Success()
        {
            //Arrange
            var ProductCountCount = 2;
            _ProductServiceMock.Setup(repo => repo.GetProducts())
          .Returns(GetTestProducts());
            var controller = new ProductsController(_ProductServiceMock.Object, _loggerMock.Object);


            //Act
            IActionResult actionResult = await controller.Get();

            // Assert

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(actionResult);
            List<Infrastrusture.Models.Products> subscriptions = Assert.IsType<List<Infrastrusture.Models.Products>>(okResult.Value);
            Assert.Equal(subscriptions.Count, ProductCountCount);
        }

        [Fact]
        public async Task AddProduct_Success()
        {
            // Arrange
            Infrastrusture.Models.Products Product = new Infrastrusture.Models.Products();
            // Product.ProductId = new Guid("");
            ProductRequest productRequest = productsRequestMock();

            _ProductServiceMock.Setup(repo => repo.AddProduct(productRequest))
                          .Returns(productsMock());


            var controller = new ProductsController(_ProductServiceMock.Object, _loggerMock.Object);
            // Act
            IActionResult actionResult = await controller.Post(productRequest);
            var okResult = actionResult as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async Task UpdateProduct_Success()
        {
            Infrastrusture.Models.Products Product = productsMock().Result;
            _ProductServiceMock.Setup(repo => repo.UpdateProduct(Product))
                .Returns(mockString());
            var controller = new ProductsController(_ProductServiceMock.Object, _loggerMock.Object);

            IActionResult actionResult = await controller.Put(Product);
            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_Success()
        {
            Guid id = new Guid();
            Infrastrusture.Models.Products Product = productsMock().Result;
            _ProductServiceMock.Setup(repo => repo.Delete(id))
                .Returns(mockString());
            var controller = new ProductsController(_ProductServiceMock.Object, _loggerMock.Object);

            IActionResult actionResult = await controller.Delete(id);
            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
        private async Task<List<Infrastrusture.Models.Products>> GetTestProducts()
        {
            List<Infrastrusture.Models.Products> products = new List<Infrastrusture.Models.Products>();
            products.Add(
                new Infrastrusture.Models.Products
                {
                    ProductId = new Guid(),
                    ProductName = "Oppo F1",
                    ProductDescription = "SmartPhone",
                    Price = 1,
                    Quantity = 2
                });
            products.Add(
               new Infrastrusture.Models.Products
               {
                   ProductId = new Guid(),
                   ProductName = "Oppo F2",
                   ProductDescription = "SmartPhone",
                   Price = 1,
                   Quantity = 2


               });
            return products;
        }

        private Infrastrusture.Models.ProductRequest productsRequestMock()
        {
            Infrastrusture.Models.ProductRequest products = new Infrastrusture.Models.ProductRequest
            {

                ProductName = "oppo",
                ProductDescription = "5g",
                Price = 5900,
                Quantity = 2
            };

            return products;

        }

        private async Task<Infrastrusture.Models.Products> productsMock()
        {
            Infrastrusture.Models.Products products = new Infrastrusture.Models.Products
            {
                ProductId = new Guid(),
                ProductName = "oppo",
                ProductDescription = "5g",
                Price = 5900,
                Quantity = 2
            };

            return products;

        }

        public async Task<string> mockString()
        {

            return "Product updated successfully";
        }
    }
}
