using System.Linq.Expressions;

namespace EmployeeSystemERPTaskAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(List<string>? includeproperties = null);
        T Get(Expression<Func<T, bool>>? filter = null, bool tracked = true, List<string>? includeproperties = null);
        void Create(T entity);
        void Remove(T entity);
        void Save();
    }
}
