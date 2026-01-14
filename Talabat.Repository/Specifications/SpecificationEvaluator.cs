using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository.Specifications
{
    public static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GenerateQuery(IQueryable<T> StartQuery, ISpecification<T> Spec)
        {
            var Query = StartQuery;
            if (Spec.Criteria != null)
            {
                Query = Query.Where(Spec.Criteria); // ⚠️ لا تستخدم Ternary Operator هنا
            }
            Query = Spec.OrderBy is not null ? Query.OrderBy(Spec.OrderBy) : Query;
            Query = Spec.OrderByDesc is not null ? Query.OrderByDescending(Spec.OrderByDesc) : Query;
            if (Spec.Take > 0) // فقط إذا كان Pagination مطلوبًا
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }
            Query = Spec.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            return Query;
        }
    }
}
