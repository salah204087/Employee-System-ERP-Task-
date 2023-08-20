using EmployeeSystemERPTaskWeb.Model.DTO;

namespace EmployeeSystemERPTaskWeb.Services.IServices
{
    public interface ILanguageLevelService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(CreateLanguageLevelDTO createLanguageLevelDTO, string token);
        Task<T> UpdateAsync<T>(LanguageLevelDTO languageLevelDTO, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
