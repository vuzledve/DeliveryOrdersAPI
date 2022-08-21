using DeliveryOrdersAPI.Domain.Repositories.Abstract;
using DeliveryOrdersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryOrdersAPI.Domain.Repositories.EntityFramework
{
    public class EFDeliveryOrdersRepository : IDeliveryOrdersRepository
    {
        private readonly AppDbContext context;
        public EFDeliveryOrdersRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<DeliveryOrder> GetDeliveryOrders()
        {
            return context.DeliveryOrders;
        }

        public void SaveDeliveryOrder(DeliveryOrder entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }
    }
}
