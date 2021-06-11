using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameBlog.Data;
using GameBlog.Models.Base;

namespace GameBlog.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id, List<Expression<Func<TEntity, object>>> includes)
        {
            var res = _context.Set<TEntity>();

            if (includes == null || includes.Count <= 0)
                return await res.SingleOrDefaultAsync(
                    e => e.Id == id);


            var query = res.Include(includes[0]);

            for (var i = 1; i < includes.Count; i++) query = query.Include(includes[i]);

            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetBySlugAsync(string slug, List<Expression<Func<TEntity, object>>> includes)
        {
            var res = _context.Set<TEntity>();

            if (includes == null || includes.Count <= 0)
                return await res.SingleOrDefaultAsync(
                    e => e.Slug == slug);


            var query = res.Include(includes[0]);

            for (var i = 1; i < includes.Count; i++) query = query.Include(includes[i]);

            return await query.SingleOrDefaultAsync(e => e.Slug == slug);
        }

        public IEnumerable<TEntity> GetAllAsync()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> GetAllAsync(int skip, int take)
        {
            var res = _context.Set<TEntity>();

            return res.Skip(skip).Take(take);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            List<Expression<Func<TEntity, object>>> includes
        )
        {
            var res = _context.Set<TEntity>();

            if (includes.Count <= 0) return await res.ToListAsync();

            var query = res.Include(includes[0]);

            for (var i = 1; i < includes.Count; i++) query = query.Include(includes[i]);

            return query.AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            List<Expression<Func<TEntity, object>>> includes,
            int skip,
            int take)
        {
            var res = _context.Set<TEntity>();

            if (includes.Count <= 0) return await res.ToListAsync();

            var query = res.Include(includes[0]);

            for (var i = 1; i < includes.Count; i++) query = query.Include(includes[i]);

            return query.Skip(skip).Take(take);
        }

        public IGenericRepository<TEntity> AddAsync(TEntity entity)
        {
            var entityEntry = _context
                .Set<TEntity>()
                .AddAsync(entity).Result;
            return this;
        }

        public IGenericRepository<TEntity> UpdateAsync(TEntity entity)
        {
            var entityEntry = _context
                .Set<TEntity>()
                .Update(entity);
            return this;
        }

        public IGenericRepository<TEntity> DeleteAsync(TEntity entity)
        {
            var entityEntry = _context
                .Set<TEntity>()
                .Remove(entity);
            return this;
        }

        public async Task LoadCollection(TEntity entity,
            Expression<Func<TEntity, IEnumerable<object>>> expressions)
        {
            var res = _context.Entry(entity);
            await res.Collection(expressions).LoadAsync();
        }

        public async Task LoadReference(TEntity entity,
            Expression<Func<TEntity, object>> expression)
        {
            var res = _context.Entry(entity);
            await res.Reference(expression).LoadAsync();
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}