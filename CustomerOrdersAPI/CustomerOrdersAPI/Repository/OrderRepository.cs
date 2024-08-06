using CustomerOrdersAPI.DAL;
using CustomerOrdersAPI.Model;

namespace CustomerOrdersAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CustomerOrdersDbContext _context;

        public OrderRepository(CustomerOrdersDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetOrdersByCustomerId(Guid customerId)
        {
           return _context.Orders
                .Where(o => o.CustomerID == customerId)
                .ToList();
        }
    }
}
