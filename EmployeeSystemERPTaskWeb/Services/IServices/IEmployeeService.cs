using EmployeeSystemERPTaskWeb.Model.DTO;

namespace EmployeeSystemERPTaskWeb.Services.IServices
{
    public interface IEmployeeService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(CreateEmployeeDTO createEmployeeDTO, string token);
        Task<T> UpdateAsync<T>(UpdateEmployeeDTO updateEmployeeDTO, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
