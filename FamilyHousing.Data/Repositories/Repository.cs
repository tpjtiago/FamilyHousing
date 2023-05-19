using FamilyHousing.Data.Contexts;
using FamilyHousing.Domain.Contracts.Repositories;
using FamilyHousing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyHousing.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly FamilyContext _context;

        private DbSet<T> _entities;
        string errorMessage = string.Empty;
        public Repository(FamilyContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            //entities.Add(entity);
            //context.SaveChanges();

            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _entities.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
