using CustomerOrdersAPI.Model;

namespace CustomerOrdersAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
