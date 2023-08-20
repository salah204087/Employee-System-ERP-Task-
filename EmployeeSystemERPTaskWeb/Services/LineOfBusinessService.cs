using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;

namespace EmployeeSystemERPTaskWeb.Services
{
    public class LineOfBusinessService:BaseService,ILineOfBusinessService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string employeeSystemUrl;

        public LineOfBusinessService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            employeeSystemUrl = configuration.GetValue<string>("ServiceUrls:EmployeeSystemAPI");
        }

        public Task<T> CreateAsync<T>(LineOfBusinessCreateDTO lineOfBusinessCreateDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = lineOfBusinessCreateDTO,
                Url = employeeSystemUrl + "/api/LineOfBusinessAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = employeeSystemUrl + "/api/LineOfBusinessAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/LineOfBusinessAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/LineOfBusinessAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(LineOfBusinessDTO lineOfBusinessDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = lineOfBusinessDTO,
                Url = employeeSystemUrl + "/api/LineOfBusinessAPI/" + lineOfBusinessDTO.Id,
                Token = token
            });
        }
    }
}
