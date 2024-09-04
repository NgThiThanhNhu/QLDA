using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
namespace Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        T Find(Expression<Func<T, bool>> match);
        void add(T entity);
        void update(T entity);
        void delete(T entity);
        void delete(Guid id);
        bool Exists(Guid id);
        int SaveChange();
        int Count();
        IEnumerable<T> ExcuteStoredProcedure(string nameOfStored, object model);
        public IEnumerable<T> ExcuteStoredProcedure(string nameofStored, SqlParameter[]? parameters);
        IQueryable<T> ExcuteStoredQuery(string query);
    }
}
