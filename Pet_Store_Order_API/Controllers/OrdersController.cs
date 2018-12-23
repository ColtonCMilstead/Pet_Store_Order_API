using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Store_Order_API.Data;
using Pet_Store_Order_API.Models;

namespace Pet_Store_Order_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("OrderPolicy")]
    public class OrdersController : ControllerBase
    {


        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        { //REQUIRED TO GATHER DUMMY DATA 
            _context = context;
        }

        // GET: api/order
        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            return _context.Orders
                .Include(o => o.Items);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderSum = await _context.Orders
             .Include(i => i.Items)
             .FirstOrDefaultAsync(i => i.OrderID == id);

            if (orderSum == null)
            {
                return NotFound();
            }

            return Ok(orderSum);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] string id, [FromBody] Order orderSum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderSum.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(orderSum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderSumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order orderSum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(orderSum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = orderSum.OrderID }, orderSum);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var orderSum = await _context.Orders.FindAsync(id);

            if (orderSum == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderSum);
            await _context.SaveChangesAsync();

            return Ok(orderSum);
        }

        private bool OrderSumExists(string id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }

        // GET api/orders/{order ID}/items
        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetItems(string id)
        {
            var items = await _context.Orders
              .Include(i => i.Items)
              .FirstOrDefaultAsync(x => x.OrderID == id);

            if (items == null)
                return NotFound();

            return Ok(items.Items);
        }

        [HttpGet("{id}/total")]
        public async Task<double> GetOrderTotal(string id)
        {
            var order = await _context.Orders
            .FirstOrDefaultAsync(x => x.OrderID == id);

            if (order == null)
                return -1;

            return order.Total; 
        }


    }
}