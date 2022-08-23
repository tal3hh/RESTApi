using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Common;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        readonly DbSet<T> table;
        public Repository(AppDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }



        public async Task CreateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            await table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            T entity = await table.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null) throw new NullReferenceException();

            return entity;

        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            T entity = await table.FindAsync(predicate);

            if (entity is null) throw new NullReferenceException();

            return entity;
        }

        public async Task SoftDeleteAsync(T entity)
        {
            T entityDb = await table.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityDb is null) throw new NullReferenceException();

            entityDb.SoftDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
