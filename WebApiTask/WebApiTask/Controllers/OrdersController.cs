using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Data;
using WebApiTask.Dtos;
using WebApiTask.Entites;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly OrderDbContext _context;
        public OrdersController(OrderDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Order>> Get()
        {
            return await _context.Orders.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderPostDto orderDto)
        {
            var order = new Order()
            {
                OrderDate =orderDto.OrderDate ,
                ProductId = orderDto.ProductId,
                CustomerId = orderDto.CustomerId,
            };
            _context.Orders.Add(order);
            _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrderPostDto orderDto)
        {
            var order = await _context.Orders.FindAsync(id);
            order.OrderDate = orderDto.OrderDate;
            order.ProductId = orderDto.ProductId;
            order.CustomerId = orderDto.CustomerId;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();


        }
    }
}
