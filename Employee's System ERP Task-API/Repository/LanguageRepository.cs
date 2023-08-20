using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Repository;
using EmployeeSystemERPTaskAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class LanguageRepository:Repository<Language>,ILanguageRepository
    {
        private readonly ApplicationDbContext _context;
        public LanguageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Language Update(Language entity)
        {
            _context.Languages.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
