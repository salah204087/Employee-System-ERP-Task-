using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository.IRepository;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class LineOfBusinessRepository : Repository<LineOfBusiness>, ILineOfBusinessRepository
    {
        private readonly ApplicationDbContext _context;
        public LineOfBusinessRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public LineOfBusiness Update(LineOfBusiness entity)
        {
            _context.LineOfBusinesses.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
