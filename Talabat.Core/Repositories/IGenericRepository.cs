using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec);
        Task<T> GetEntityWithSpecAsync(ISpecification<T> Spec);
        Task<T> GetByIdAsync(int Id);
        int GetCountAsync(ISpecification<T> Spec);
        Task AddAsync(T Item);
        void Delete(T Item);
        void Update(T Item);
    }
}
