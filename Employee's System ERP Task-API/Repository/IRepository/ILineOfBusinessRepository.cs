using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository.IRepository;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface ILineOfBusinessRepository:IRepository<LineOfBusiness>
    {
        LineOfBusiness Update(LineOfBusiness entity);
    }
}
