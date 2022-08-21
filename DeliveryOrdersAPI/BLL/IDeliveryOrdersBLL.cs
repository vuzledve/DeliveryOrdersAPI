using DeliveryOrdersAPI.Domain;
using DeliveryOrdersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryOrdersAPI.BLL
{
    public interface IDeliveryOrdersBLL
    {

        public Task<ActionResult<IEnumerable<DeliveryOrder>>> GetDeliveryOrders();

        public Task<int> PostDeliveryOrder(DeliveryOrder deliveryOrder);

    }
}
