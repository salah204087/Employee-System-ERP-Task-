using EmployeeSystemERPTaskWeb.Model.DTO;

namespace EmployeeSystemERPTaskWeb.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO registerRequestDTO);
    }
}
