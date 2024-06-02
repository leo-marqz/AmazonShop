
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AmazonShop.Application.Persistence;
using AmazonShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AmazonShop.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AmazonShopDbContext _db;

        public RepositoryBase(AmazonShopDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public void AddEntity(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public void DeleteEntity(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void DeleteRange(IReadOnlyList<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeString, bool disableTracking = true)
        {
            IQueryable<T> query = _db.Set<T>();
            if(disableTracking) query = query.AsNoTracking();
            if(!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if(predicate != null) query = query.Where(predicate);
            if(orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _db.Set<T>();
            if(disableTracking) query = query.AsNoTracking();
            if(includes != null) query = includes.Aggregate(query, (current, include)=>current.Include(include));
            if(predicate != null) query = query.Where(predicate);
            if(orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return (await _db.Set<T>().FindAsync(id))!;
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _db.Set<T>();
            if(disableTracking) query = query.AsNoTracking();
            if(includes != null) query = includes.Aggregate(query, (current, include)=>current.Include(include));
            if(predicate != null) query = query.Where(predicate);

            return (await query.FirstOrDefaultAsync())!;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public void UpdateEntity(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}