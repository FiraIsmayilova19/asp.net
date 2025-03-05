using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Data;
using WebApiTask.Dtos;
using WebApiTask.Entites;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducsController : Controller
    {
        private readonly OrderDbContext _context;
        public ProducsController(OrderDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductPostDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Discount = productDto.Discount,
            };
            _context.Products.Add(product);
            _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductPostDto productDro)
        {
            var product = await _context.Products.FindAsync(id);
            product.Name = productDro.Name;
            product.Price = productDro.Price;
            product.Discount = productDro.Discount;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}