using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CodeForFun.Core.Entities;

namespace CodeForFun.Core
{
    public interface IQueryableRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);
        Task<T> Get(Expression<Func<T, bool>> predicate);
    }
}