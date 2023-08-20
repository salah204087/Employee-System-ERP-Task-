using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface IEmployeeLangLevelRepository:IRepository<EmployeeLangLevel>
    {
        EmployeeLangLevel Update(EmployeeLangLevel entity);
    }
}
