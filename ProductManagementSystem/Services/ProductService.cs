using ProductManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Services
{
    internal class ProductService
    {

      private List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public List<Product> GetAllProducts()
        {
            return products;
        }
        //Search product 
        public Product? GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
        //Filter product(later)
        public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }
        public bool RemoveProduct(int id)
        {
            var id1 = products.FirstOrDefault(p => p.Id == id);
            var product = GetProductById(id);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }
    }

}
