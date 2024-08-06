using CustomerOrdersAPI.DAL;
using CustomerOrdersAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrdersAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerOrdersDbContext _context;

        public CustomerRepository(CustomerOrdersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }
    }
}
