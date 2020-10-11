using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.Business.Abstract.Services
{
	public interface IProductsToCustomer : IService<ProductsToCustomer>, IServiceForQueryable<ProductsToCustomer>
	{
	}
}
