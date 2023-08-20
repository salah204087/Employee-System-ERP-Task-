using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository;
using EmployeeSystemERPTaskAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class LanguageLevelRepository:Repository<LanguageLevel>, ILanguageLevelRepository
    {
        private readonly ApplicationDbContext _context;
        public LanguageLevelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public LanguageLevel Update(LanguageLevel entity)
        {
            _context.LanguageLevels.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
