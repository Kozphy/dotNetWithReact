using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Soup",
                },
                new Product
                {
                    Id = 2,
                    Name = "Cup",
                },
                new Product
                {
                    Id = 3,
                    Name = "Strawberry"
                }
            };
        }

        public async Task AddProduct(Product product)
        {
              _products.Add(product);
              await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.FromResult(_products);
        }
    }
}