using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _context.Product.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductsById(int id)
        {
            var pro = await _context.Product.FindAsync(id);
            if (pro == null)
            {
                return NotFound();
            }
            return pro;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product prod)
        {
            await _context.Product.AddAsync(prod);
            await _context.SaveChangesAsync();
            return Ok(prod);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product prod)
        {
            if (id != prod.Id)
            {
                return BadRequest();
            }
            _context.Entry(prod).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(prod);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var del = await _context.Product.FindAsync(id);
            if (del == null)
            {
                return NotFound();
            }
            _context.Product.Remove(del);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}