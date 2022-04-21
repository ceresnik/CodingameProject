using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace SWCraftProject.DIPExample.good
{
    class ProductCatalog
    {
        private readonly IProductRepository myProductRepository;

        public ProductCatalog(IProductRepository productRepository)
        {
            myProductRepository = productRepository;
        }

        public void ListAllProducts()
        {
            IList<string> productNames = myProductRepository.GetAllProductNames();
            Console.WriteLine(string.Join(", ", productNames));
        }
    }

    public interface IProductRepository
    {
        IList<string> GetAllProductNames();
    }

    public class ProductCatalogTests
    {
        [Test]
        public void Test()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            IList<string> testProductNames = new List<string>
            {
                "testProduct1", "testProduct2"
            };
            mockProductRepository.Setup(x => x.GetAllProductNames()).Returns(testProductNames);
            var productCatalog = new ProductCatalog(mockProductRepository.Object);
            productCatalog.ListAllProducts();
        }
    }

}
