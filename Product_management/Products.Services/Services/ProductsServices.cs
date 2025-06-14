using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.DataAccess.Models;
using Products.DataAccess.Repositories;

namespace Products.Services.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public int UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

    }
}
