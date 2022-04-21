using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SWCraftProject.DIPExample
{
    class ProductCatalog
    {
        public void ListAllProducts()
        {
            var sqlProductRepository = new SqlProductRepository();
            IList<string> productNames = sqlProductRepository.GetAllProductNames();
            Console.WriteLine(string.Join(", ", productNames));
        }
    }

    internal class SqlProductRepository
    {
        public IList<string> GetAllProductNames()
        {
            return new List<string>{"soap", "toothpaste", "shampoo"};
        }
    }

    public class ProductCatalogTests
    {
        [Test]
        public void Test()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.ListAllProducts();
        }
    }
}
