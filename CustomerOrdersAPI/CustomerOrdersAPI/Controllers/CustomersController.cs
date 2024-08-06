using Microsoft.AspNetCore.Mvc;
using CustomerOrdersAPI.Model;
using CustomerOrdersAPI.Repository;

namespace CustomerOrdersAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomers();
                // List<Customer> customers = _context.Customers.ToList();
                //if (customers == null || customers.Count() == 0)
                if (customers == null || !customers.Any())
                {
                    return NotFound("No customers found");
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
