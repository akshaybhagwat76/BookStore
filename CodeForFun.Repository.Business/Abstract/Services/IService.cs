using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Abstract.Services
{
	public interface IService<T> where T:class,new()
	{
        Task<T> GetAsync(int id);
        Task<List<T>> GetListAsync();


        void AddAsync(T entity);
        void AddRangeAsync(List<T> entities);


        void UpdateAsync(T entity);
        void UpdateRangeAsync(List<T> entities);


        void DeleteAsync(T entity);
        void DeleteRangeAsync(IEnumerable<int> ids);
    }
}
