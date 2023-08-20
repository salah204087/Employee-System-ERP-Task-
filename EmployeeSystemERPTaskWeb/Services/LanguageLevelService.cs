using EmployeeSystemERPTaskAPI.Repository.IRepository;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;

namespace EmployeeSystemERPTaskWeb.Services
{
    public class LanguageLevelService:BaseService,ILanguageLevelService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string employeeSystemUrl;

        public LanguageLevelService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            employeeSystemUrl = configuration.GetValue<string>("ServiceUrls:EmployeeSystemAPI");
        }

        public Task<T> CreateAsync<T>(CreateLanguageLevelDTO createLanguageLevelDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = createLanguageLevelDTO,
                Url = employeeSystemUrl + "/api/LanguageLevelAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = employeeSystemUrl + "/api/LanguageLevelAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/LanguageLevelAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = employeeSystemUrl + "/api/LanguageLevelAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(LanguageLevelDTO languageLevelDTO, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = languageLevelDTO,
                Url = employeeSystemUrl + "/api/LanguageLevelAPI/" + languageLevelDTO.Id,
                Token = token
            });
        }
    }
}
