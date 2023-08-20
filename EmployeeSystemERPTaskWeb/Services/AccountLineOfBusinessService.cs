using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;

namespace EmployeeSystemERPTaskWeb.Services
{
    public class AccountLineOfBusinessService : BaseService, IAccountLineOfBusinessService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string employeeSystemUrl;

        public AccountLineOfBusinessService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            employeeSystemUrl = configuration.GetValue<string>("ServiceUrls:EmployeeSystemAPI");
        }
        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/AccountLineAPI",
                Token = token
            });
        }
    }
}
