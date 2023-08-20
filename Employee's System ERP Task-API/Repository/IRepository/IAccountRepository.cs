using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface IAccountRepository:IRepository<Account>
    {
        Account Update(Account entity);
    }
}
