using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;
using Talabat.Repository.Specifications;

namespace Talabat.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TalabatContext _dbContext;

        public GenericRepository(TalabatContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec)
            => await CallSpecEvaluator(Spec).ToListAsync();

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> Spec)
            => await CallSpecEvaluator(Spec).FirstOrDefaultAsync();


        public IQueryable<T> CallSpecEvaluator(ISpecification<T> Spec)
            => SpecificationEvaluator<T>.GenerateQuery(_dbContext.Set<T>(), Spec);

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int Id)
            => await _dbContext.Set<T>().FindAsync(Id);

        public int GetCountAsync(ISpecification<T> Spec)
        {
            var result = CallSpecEvaluator(Spec).ToList();
            var count = result.Count();
            return count;
        }

        public async Task AddAsync(T Item)
            => await _dbContext.Set<T>().AddAsync(Item);

        public void Delete(T Item)
            => _dbContext.Set<T>().Remove(Item);

        public void Update(T Item)
            => _dbContext.Set<T>().Update(Item);

    }

}
