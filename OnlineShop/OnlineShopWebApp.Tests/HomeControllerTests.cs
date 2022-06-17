using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.ViewModels;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly HomeController controller;
        public HomeControllerTests()
        {
            productRepository = new Mock<IProductRepository>();
            controller = new HomeController(productRepository.Object);
        }

        [TestMethod]
        public void Index_GetAllFromProductRepostory_ListProductViewModel()
        {
            // Arrange
            var testProducts = new List<Product>
            {
                new Product 
                {
                    Id = new Guid("8b4d6e1b-5223-4172-aaf6-f160518b101e"),
                    Name = "Букварь",
                    Cost = 356,
                    Description = "lorem...",
                    Images = new List<Image>
                    {
                        new Image
                        { Id = new Guid("81022697-a68b-49fd-b531-3c646af35f4d"),
                          Path = "/images/product/dsddsds.bmp",
                          ProductId = new Guid("8b4d6e1b-5223-4172-aaf6-f160518b101e")
                        }
                    }
                },
                new Product
                {
                    Id = new Guid("638f67fe-7951-4bd8-ad96-f3ea3eebf616"),
                    Name = "Неезнайка",
                    Cost = 690,
                    Description = "lorem...",
                    Images = new List<Image>
                    {
                        new Image
                        { Id = new Guid("0ed68e46-7aa2-41c2-9fe7-fc78080b3171"),
                          Path = "/images/product/dsddsds.bmp",
                          ProductId = new Guid("638f67fe-7951-4bd8-ad96-f3ea3eebf616")
                        }
                    }
                }

            };

            var expected = testProducts.MappingToListProductViewModel();

            
            productRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(testProducts);
            var controller = new HomeController(productRepository.Object);
           

            // Act

            var actual = controller.Index().Result as ViewResult;
            var model = actual.Model as List<ProductViewModel>;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, model.Count);
            
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, model[i].Id);
                Assert.AreEqual(expected[i].Name, model[i].Name);
                Assert.AreEqual(expected[i].Description, model[i].Description);
                Assert.AreEqual(expected[i].Cost, model[i].Cost);
                Assert.AreEqual(expected[i].MainImagePath, model[i].MainImagePath);
            }
            
            

        }
    }
}
