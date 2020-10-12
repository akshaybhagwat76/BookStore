using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Abstract
{
	public interface IRepositoryWrapper
	{
		ICategory Category { get; }
		ICustomer Customer { get; }
		IProduct Product { get; }
		IProductDetails ProductDetails { get; }
		IUser User { get; }
		IProductsToCustomers ProductsToCustomers { get; }
		IBooks Books { get; }
		IOrders Orders { get; }
	}
}
