using CustomerOrdersAPI.Model;
using CustomerOrdersBlazor.Api;

namespace CustomerOrdersBlazor.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CustomerService> _logger;


        public CustomerService(HttpClient httpClient, ILogger<CustomerService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient.BaseAddress = ApiConfig.BaseAddress;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {
                string requestUri = "api/customers";
                _logger.LogInformation($"Sending request to: {requestUri}");

                var response = await _httpClient.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Request successful.");
                    var customers = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
                    return customers;
                }
                else
                {
                    _logger.LogError($"Request failed with status code: {response.StatusCode}");
                    return Enumerable.Empty<Customer>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex.Message}");
                throw; 
            }
        }

}
}
