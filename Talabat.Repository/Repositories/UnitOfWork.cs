using System.Collections;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TalabatContext _context;
        private readonly Hashtable _repositories;

        public UnitOfWork(TalabatContext Context)
        {
            _context = Context;
            _repositories = new Hashtable();
        }
        public async Task<int> Complete()
        => await _context.SaveChangesAsync();


        public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity).Name))
            {
                return _repositories[typeof(TEntity).Name] as IGenericRepository<TEntity>;
            }
            var repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity).Name, repository);
            return repository;
        }
    }
}
