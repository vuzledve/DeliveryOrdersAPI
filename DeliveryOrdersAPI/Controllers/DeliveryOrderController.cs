using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryOrdersAPI.Domain;
using DeliveryOrdersAPI.Models;
using DeliveryOrdersAPI.BLL;

namespace DeliveryOrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryOrderController : ControllerBase
    {

        private readonly IDeliveryOrdersBLL _logic;

        public DeliveryOrderController(IDeliveryOrdersBLL logic)
        {
            _logic = logic;
        }

        // GET: api/DeliveryOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryOrder>>> GetDeliveryOrders()
        {
            return Ok(_logic.GetDeliveryOrders());
        }

 
        // POST: api/DeliveryOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryOrder>> PostDeliveryOrder(DeliveryOrder deliveryOrder)
        {
           switch ( await _logic.PostDeliveryOrder(deliveryOrder))
           {
                case 200: return Ok(deliveryOrder);

                case 204: return BadRequest();

                default: return NotFound();
           }
           
        }

     
    }
}
