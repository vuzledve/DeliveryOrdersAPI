using DeliveryOrdersAPI.Models;

namespace DeliveryOrdersAPI.Domain.Repositories.Abstract
{
    public interface IDeliveryOrdersRepository
    {
        IQueryable<DeliveryOrder> GetDeliveryOrders();
        void SaveDeliveryOrder(DeliveryOrder entity);

    }
}
