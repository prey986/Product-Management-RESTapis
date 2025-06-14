using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.DataAccess.Models;

namespace Products.DataAccess.Repositories
{
    public class ProductRepository
    {
        private readonly ProductsDbContext _context;

        public ProductRepository(ProductsDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public int UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct == null)
                return -1;

            existingProduct.Productname = product.Productname;
            existingProduct.Price = product.Price;
            _context.SaveChanges();
            return 1;
        }

        public int DeleteProduct(int id)
        {
            var productToRemove = GetProductById(id);
            if (productToRemove == null)
                return -1;

            _context.Products.Remove(productToRemove);
            _context.SaveChanges();
            return 1;
        }

      
    }
}
