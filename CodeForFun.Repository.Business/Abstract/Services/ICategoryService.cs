using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Abstract.Services
{
	public interface ICategoryService:IService<Category>, IServiceForQueryable<Category>
	{
		public Task<Category> GetByName(string name);
	}
}
