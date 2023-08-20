using EmployeeSystemERPTaskAPI.Data;
using EmployeeSystemERPTaskAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace EmployeeSystemERPTaskAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public void Create(T entity)
        {
            dbSet.Add(entity);
            Save();
        }

        public T Get(Expression<Func<T, bool>>? filter = null, bool tracked = true, List<string>? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
                query = query.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);
            if (includeproperties != null)
            {
                foreach (var property in includeproperties)
                {
                    foreach (var item in property.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        query = query.Include(item);
                }

            }
            return query.FirstOrDefault();
        }

        public List<T> GetAll(List<string>? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (includeproperties != null)
            {
                foreach (var property in includeproperties)
                {
                    foreach (var item in property.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
