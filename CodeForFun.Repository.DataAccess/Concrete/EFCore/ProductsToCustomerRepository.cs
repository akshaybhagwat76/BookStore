using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Concrete.EFCore
{
	public class ProductsToCustomersRepository: GenereticRepository<ProductsToCustomer, RepositoryContext>, IProductsToCustomers
	{
		public ProductsToCustomersRepository(RepositoryContext context) : base(context) { }
	}
}
