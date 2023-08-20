using EmployeeSystemERPTaskWeb.Model.DTO;

namespace EmployeeSystemERPTaskWeb.Services.IServices
{
    public interface ILineOfBusinessService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(LineOfBusinessCreateDTO lineOfBusinessCreateDTO, string token);
        Task<T> UpdateAsync<T>(LineOfBusinessDTO lineOfBusinessDTO, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
