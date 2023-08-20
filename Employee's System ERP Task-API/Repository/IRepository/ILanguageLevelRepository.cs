using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface ILanguageLevelRepository:IRepository<LanguageLevel>
    {
        LanguageLevel Update(LanguageLevel entity);
    }
}
