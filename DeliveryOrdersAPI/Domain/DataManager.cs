using DeliveryOrdersAPI.Domain.Repositories.Abstract;
namespace DeliveryOrdersAPI.Domain
{

    //точка входа для DbContext
    public class DataManager
    {
        public IDeliveryOrdersRepository DeliveryOrders { get; set; }
    

        public DataManager(IDeliveryOrdersRepository deliveryOrdersRepository)
        {
            DeliveryOrders = deliveryOrdersRepository;
        }
    }
}
