using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository.IRepository;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class EmployeeLangLevelRepository : Repository<EmployeeLangLevel>, IEmployeeLangLevelRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeLangLevelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public EmployeeLangLevel Update(EmployeeLangLevel entity)
        {
            _context.EmployeeLangLevels.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
