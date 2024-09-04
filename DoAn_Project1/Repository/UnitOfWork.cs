using AutoDependencyRegistration.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UnitOfWork<TContext> :
        IRepositoryFactory,
        IUnitOfWork<TContext>,
        IUnitOfWork,
        IDisposable
        where TContext : DbContext, IDisposable
    {
        private Dictionary<Type, object> _repositories;
        private bool disposed = false;

        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (this._repositories == null)
                this._repositories = new Dictionary<Type, object>();
            Type key = typeof(TEntity);
            if (!this._repositories.ContainsKey(key))
                this._repositories[key] = (object)new Repository<TEntity>((DbContext)this.Context);
            return (IRepository<TEntity>)this._repositories[key];
        }   

        public int StoreProcedureWithOuput(string sql, params object[] args)
        {
            return this.Context.Database.ExecuteSqlRaw(sql, args);
        }

        public int Commit(bool autoHistory = false) => this.Context.SaveChanges();

        public async Task<int> CommitAsync(bool autoHistory = false)
        {
            int num = await this.Context.SaveChangesAsync(new CancellationToken());
            return num;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                this.Context.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }
    }

}
