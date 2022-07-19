using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Base.Specifications;

namespace E_Commerce_App_Practices_1.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> getAllAsync();
        
        Task<T> getByIdAsync(int id);


        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
