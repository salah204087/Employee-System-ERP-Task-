using EmployeeSystemERPTaskAPI.Model;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface IAccount_LineOfBusinessRepository:IRepository<Account_LineOfBusiness>
    {
        Account_LineOfBusiness Update(Account_LineOfBusiness entity);
    }
}
