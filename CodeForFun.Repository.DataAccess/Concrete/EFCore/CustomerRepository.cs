using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.Core;

namespace CodeForFun.Repository.DataAccess.Concrete.EFCore
{
    public class CustomerRepository : GenereticRepository<Customer, RepositoryContext>,ICustomer
    {
        public CustomerRepository(RepositoryContext context) : base(context) { }
    }
}