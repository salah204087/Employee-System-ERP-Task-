using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee Update(Employee entity);
    }
}
