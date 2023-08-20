

using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository.IRepository;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class Account_LineOfBusinessRepository : Repository<Account_LineOfBusiness>,IAccount_LineOfBusinessRepository
    {
        private readonly ApplicationDbContext _context;
        public Account_LineOfBusinessRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Account_LineOfBusiness Update(Account_LineOfBusiness entity)
        {
            _context.account_LineOfBusinesses.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
