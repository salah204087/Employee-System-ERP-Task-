using EmployeeSystemERPTaskAPI.Model.DTO;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string name);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
