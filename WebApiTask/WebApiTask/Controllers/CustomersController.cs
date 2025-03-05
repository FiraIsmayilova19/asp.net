using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Data;
using WebApiTask.Dtos;
using WebApiTask.Entites;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly OrderDbContext _context;
        public CustomersController(OrderDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post(CustomerPostDto customerDto)
        {
            var customer = new Customer()
            {
                Name = customerDto.Name,
                SurName=customerDto.SurName,
            };
            _context.Customers.Add(customer);
            _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,CustomerPostDto customerDto)
        {
            var customer = await _context.Customers.FindAsync(id);
            customer.Name=customerDto.Name;
            customer.SurName=customerDto.SurName;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {


            var customer = await _context.Customers.FindAsync(id);
             _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
