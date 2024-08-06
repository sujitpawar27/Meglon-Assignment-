using CustomerOrdersAPI.Model;
using CustomerOrdersBlazor.Api;


namespace CustomerOrdersBlazor.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OrderService> _logger;

        public OrderService(HttpClient httpClient, ILogger<OrderService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _httpClient.BaseAddress = ApiConfig.BaseAddress;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(string customerId)
        {
            try
            {
                string requestUri = $"api/orders/{customerId}";
                _logger.LogInformation($"Sending request to: {requestUri}");

                var response = await _httpClient.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Request successful.");
                    var orders = await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
                    return orders;
                }
                else
                {
                    _logger.LogError($"Request failed with status code: {response.StatusCode}");
                    return Enumerable.Empty<Order>();
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
