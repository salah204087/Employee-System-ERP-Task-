using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository.IRepository;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Employee Update(Employee entity)
        {
            _context.Employees.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
