using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository.IRepository;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Account Update(Account entity)
        {
            _context.Accounts.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
