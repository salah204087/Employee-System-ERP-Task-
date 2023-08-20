namespace EmployeeSystemERPTaskWeb.Services.IServices
{
    public interface IAccountLineOfBusinessService
    {
        Task<T> GetAllAsync<T>(string token);
    }
}
