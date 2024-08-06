using CustomerOrdersAPI.Model;

namespace CustomerOrdersAPI.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersByCustomerId(Guid customerId);

    }
}
