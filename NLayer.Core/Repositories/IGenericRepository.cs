﻿using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        //productRepostory.where(x => x.id >5).ToListAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}