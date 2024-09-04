namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Commit(bool autoHistory = false);
        Task<int> CommitAsync(bool autoHistory = false);

    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : class
    {
        TContext Context { get; }
    }

}
