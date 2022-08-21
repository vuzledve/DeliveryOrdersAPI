using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryOrdersAPI.Domain;
using DeliveryOrdersAPI.Models;

namespace DeliveryOrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeliveryOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryOrder>>> GetDeliveryOrders()
        {
          if (_context.DeliveryOrders == null)
          {
              return NotFound();
          }
          return Ok(await _context.DeliveryOrders.ToListAsync());
           // return await _context.DeliveryOrders.ToListAsync();
        }

        // GET: api/DeliveryOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryOrder>> GetDeliveryOrder(Guid id)
        {
          if (_context.DeliveryOrders == null)
          {
              return NotFound();
          }
            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);

            if (deliveryOrder == null)
            {
                return NotFound();
            }

            return deliveryOrder;
        }

        // PUT: api/DeliveryOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryOrder(Guid id, DeliveryOrder deliveryOrder)
        {
            if (id != deliveryOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryOrderExists(id))
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

        // POST: api/DeliveryOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryOrder>> PostDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            if (_context.DeliveryOrders == null)
            {
                return Problem("Entity set 'AppDbContext.DeliveryOrders'  is null.");
            }
            deliveryOrder.OrderNum = _context.DeliveryOrders.Count() + 1;
            _context.DeliveryOrders.Add(deliveryOrder);
            await _context.SaveChangesAsync();
            return Ok(deliveryOrder);
            //return CreatedAtAction("GetDeliveryOrder", new { id = deliveryOrder.Id }, deliveryOrder);
        }

        // DELETE: api/DeliveryOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryOrder(Guid id)
        {
            if (_context.DeliveryOrders == null)
            {
                return NotFound();
            }
            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);
            if (deliveryOrder == null)
            {
                return NotFound();
            }

            _context.DeliveryOrders.Remove(deliveryOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryOrderExists(Guid id)
        {
            return (_context.DeliveryOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
