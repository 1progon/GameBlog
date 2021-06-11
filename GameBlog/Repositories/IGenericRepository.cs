using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameBlog.Models.Base;

namespace GameBlog.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<TEntity> GetByIdAsync(int id, List<Expression<Func<TEntity, object>>> includes);

        Task<TEntity> GetBySlugAsync(string slug, List<Expression<Func<TEntity, object>>> includes);

        IEnumerable<TEntity> GetAllAsync();
        IEnumerable<TEntity> GetAllAsync(int skip, int take);
        Task<IEnumerable<TEntity>> GetAllAsync(List<Expression<Func<TEntity, object>>> includes);
        Task<IEnumerable<TEntity>> GetAllAsync(List<Expression<Func<TEntity, object>>> includes, int skip, int take);

        IGenericRepository<TEntity> AddAsync(TEntity entity);
        IGenericRepository<TEntity> UpdateAsync(TEntity entity);
        IGenericRepository<TEntity> DeleteAsync(TEntity entity);

        Task LoadCollection(TEntity entity,
            Expression<Func<TEntity, IEnumerable<object>>> expressions);

        Task LoadReference(TEntity entity,
            Expression<Func<TEntity, object>> expression);

        int Count();

        Task<int> SaveChangesAsync();
    }
}