using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface ILanguageRepository:IRepository<Language>
    {
        Language Update(Language entity);
    }
}
