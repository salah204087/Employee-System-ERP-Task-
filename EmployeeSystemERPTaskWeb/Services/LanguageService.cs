using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;

namespace EmployeeSystemERPTaskWeb.Services
{
    public class LanguageService : BaseService, ILanguageService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string employeeSystemUrl;

        public LanguageService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            employeeSystemUrl = configuration.GetValue<string>("ServiceUrls:EmployeeSystemAPI");
        }

        public Task<T> CreateAsync<T>(CreateLanguageDTO createLanguageDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = createLanguageDTO,
                Url = employeeSystemUrl + "/api/LanguageAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = employeeSystemUrl + "/api/LanguageAPI/"+id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/LanguageAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/LanguageAPI/"+id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(LanguageDTO languageDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = languageDTO,
                Url = employeeSystemUrl + "/api/LanguageAPI/"+languageDTO.Id,
                Token = token
            });
        }
    }
}
