using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;

namespace EmployeeSystemERPTaskWeb.Services
{
    public class AccountService:BaseService,IAccountService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string employeeSystemUrl;

        public AccountService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            employeeSystemUrl = configuration.GetValue<string>("ServiceUrls:EmployeeSystemAPI");
        }

        public Task<T> CreateAsync<T>(CreateAccountDTO createAccountDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = createAccountDTO,
                Url = employeeSystemUrl + "/api/AccountAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = employeeSystemUrl + "/api/AccountAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/AccountAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/AccountAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(AccountDTO accountDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = accountDTO,
                Url = employeeSystemUrl + "/api/AccountAPI/" + accountDTO.Id,
                Token = token
            });
        }
    }
}
