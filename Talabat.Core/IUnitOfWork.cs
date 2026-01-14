using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public Task<int> Complete();
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
