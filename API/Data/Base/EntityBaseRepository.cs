using API.Data;
using API.Data.Base.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App_Practices_1.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly StoreContext _context;

        public EntityBaseRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var resutl = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(resutl);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }


        public async Task<IEnumerable<T>> getAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();

            return result;
        }

        public async Task<T> getByIdAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
