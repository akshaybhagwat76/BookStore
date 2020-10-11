using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.Repository.Entities.Concrete.CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Abstract.Services
{
	public interface IProductService : IService<Product>, IServiceForQueryable<Product>
	{
		public Task<Product> GetByName(string name);
	}
}
