using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CodeForFun.Core.Entities;

namespace CodeForFun.Core
{
    public interface IEntityRepository<T> where T : class, new()
    {
        //
        void Create(T entity);
        void CreateAsync(T entity);

        //
        void CreateRange(List<T> entities);
        void CreateRangeAsync(List<T> entities);
        
        
        //
        T Read(Expression<Func<T, bool>> filter);
        Task<T> ReadAsync(Expression<Func<T, bool>> filter);

        //
        List<T> ReadList(Expression<Func<T, bool>> filter = null);
        Task<List<T>> ReadListAsync(Expression<Func<T, bool>> filter = null);


        //
        void Update(T entity);
        void UpdateAsync(T entity);

        //
        void UpdateRange(List<T> entities);
        void UpdateRangeAsync(List<T> entities);

        
        //
        void Delete(T entity);
        void DeleteAsync(T entity);

        //
        void DeleteRange(List<T> entities);
        void DeleteRangeAsync(List<T> entities);
    }
}