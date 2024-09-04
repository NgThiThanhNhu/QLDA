using AutoDependencyRegistration.Attributes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;


namespace Repository
{
  
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        private object context;

        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<T>();
        }
        public virtual IQueryable<T> GetAll()
        {
            return (IQueryable<T>)this._dbSet;
        }

        public virtual T GetById(Guid id)
        {
            return this._dbSet.Find((object)id);
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {

            return this._dbSet.SingleOrDefault<T>(match);
        }

        public virtual void add(T entity)
        {
            EntityEntry entityEntry = (EntityEntry)this._dbContext.Entry<T>(entity);
            if (entityEntry.State != 0)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this._dbSet.Add(entity);
            }
        }

        public virtual void update(T entity)
        {
            EntityEntry entityEntry = (EntityEntry)this._dbContext.Entry<T>(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                this._dbSet.Attach(entity);
            }

            entityEntry.State = EntityState.Modified;
        }

        public virtual void delete(T entity)
        {
            EntityEntry entityEntry = (EntityEntry)this._dbContext.Entry<T>(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this._dbSet.Attach(entity);
                this._dbSet.Remove(entity);
            }
        }

        public void delete(Guid id)
        {
            T byId = this.GetById(id);
            if ((object)byId == null)
            {
                return;
            }
            this.delete(byId);
        }

        public virtual bool Exists(Guid id)
        {
            return (object)this._dbSet.Find((object)id) != null;
        }

        public virtual int SaveChange()
        {
            return this._dbContext.SaveChanges();
        }

        public virtual int Count()
        {
            return this._dbSet.Count<T>();
        }

        public virtual IEnumerable<T> ExcuteStoredProcedure(string nameOfStored, object model)
        {
            if (this._dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                this._dbContext.Database.OpenConnection();
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();
            using (DbCommand command = this._dbContext.Database.GetDbConnection().CreateCommand())
            {
                foreach (PropertyInfo property in model.GetType().GetProperties())
                    sqlParameterList.Add(new SqlParameter(property.Name, property.GetValue(model)));
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = nameOfStored;
                command.Parameters.AddRange((Array)sqlParameterList.ToArray());
                DataTable tbl = new DataTable();
                using (DbDataReader reader = command.ExecuteReader())
                    tbl.Load((IDataReader)reader);
                command.Parameters.Clear();
                return (IEnumerable<T>)tbl.ToList<T>();
            }
        }

        public IEnumerable<T> ExcuteStoredProcedure(string nameofStored, SqlParameter[]? parameters)
        {
            if (this._dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                this._dbContext.Database.OpenConnection();
            using (DbCommand command = this._dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = 180;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = nameofStored;
                if (parameters != null)
                    command.Parameters.AddRange((Array)parameters);
                DataTable tbl = new DataTable();
                using (DbDataReader reader = command.ExecuteReader())
                    tbl.Load((IDataReader)reader);
                command.Parameters.Clear();
                return (IEnumerable<T>)tbl.ToList<T>();
            }
        }

        public IQueryable<T> ExcuteStoredQuery(string query)
        {
            return this._dbSet.FromSqlRaw<T>(query).IgnoreQueryFilters<T>();
        }

        public virtual void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
