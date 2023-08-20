using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;

namespace EmployeeSystemERPTaskWeb.Services
{
    public class EmployeeService:BaseService,IEmployeeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string employeeSystemUrl;

        public EmployeeService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            employeeSystemUrl = configuration.GetValue<string>("ServiceUrls:EmployeeSystemAPI");
        }

        public Task<T> CreateAsync<T>(CreateEmployeeDTO createEmployeeDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = createEmployeeDTO,
                Url = employeeSystemUrl + "/api/EmployeeAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = employeeSystemUrl + "/api/EmployeeAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/EmployeeAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/EmployeeAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(UpdateEmployeeDTO updateEmployeeDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = updateEmployeeDTO,
                Url = employeeSystemUrl + "/api/EmployeeAPI/" + updateEmployeeDTO.Id,
                Token = token
            });
        }
    }
}
