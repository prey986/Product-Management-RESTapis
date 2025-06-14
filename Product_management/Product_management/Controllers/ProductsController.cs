using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Services.Services;
using Products.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;


namespace Product_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles="admin,manager")]
        public IActionResult Add(Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin,manager")]

        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("Product ID mismatch");

            var result = _productService.UpdateProduct(product);
            if (result == -1)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,manager")]

        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (result == -1)
                return NotFound();

            return NoContent();
        }

    }
}
