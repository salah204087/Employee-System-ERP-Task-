using EmployeeSystemERPTaskWeb.Model.DTO;

namespace EmployeeSystemERPTaskWeb.Services.IServices
{
    public interface IAccountService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(CreateAccountDTO createAccountDTO, string token);
        Task<T> UpdateAsync<T>(AccountDTO accountDTO, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
