using EmployeeSystemERPTaskWeb.Model.DTO;

namespace EmployeeSystemERPTaskWeb.Services.IServices
{
    public interface ILanguageService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(CreateLanguageDTO createLanguageDTO, string token);
        Task<T> UpdateAsync<T>(LanguageDTO languageDTO, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
