using DeliveryOrdersAPI.Domain;
using DeliveryOrdersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryOrdersAPI.BLL
{
    public class DeliveryOrdersBLL : IDeliveryOrdersBLL
    {
        private readonly AppDbContext _context;
        public DeliveryOrdersBLL(AppDbContext context)
        {
            _context = context;
        }
        async Task<ActionResult<IEnumerable<DeliveryOrder>>> IDeliveryOrdersBLL.GetDeliveryOrders()
        {
            if (_context.DeliveryOrders == null)
            {
                return null;
            }
            return await _context.DeliveryOrders.ToListAsync();
        }

        public async Task<int> PostDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            if (_context.DeliveryOrders == null)
            {
                return 204;
            }
            deliveryOrder.OrderNum = _context.DeliveryOrders.Count() + 1;
            _context.DeliveryOrders.Add(deliveryOrder);
            await _context.SaveChangesAsync();
            return 200;
        }
    }
}
