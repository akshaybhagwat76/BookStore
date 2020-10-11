using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Abstract.Services
{
	public interface IServiceForQueryable<T>where T:class,new()
	{
		Task<List<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);
	}
}
