using EmployeeSystemERPTaskWeb.Model.DTO;
using EmployeeSystemERPTaskUtility;
using EmployeeSystemERPTaskWeb.Models;
using EmployeeSystemERPTaskWeb.Services.IServices;

namespace EmployeeSystemERPTaskWeb.Services
{
    public class AuthService:BaseService,IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string employeeSystemUrl;
        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            employeeSystemUrl = configuration.GetValue<string>("ServiceUrls:EmployeeSystemAPI");
        }
        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDTO,
                Url = employeeSystemUrl + "/api/userAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO registerRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registerRequestDTO,
                Url = employeeSystemUrl + "/api/userAuth/register"
            });
        }
    }
}
