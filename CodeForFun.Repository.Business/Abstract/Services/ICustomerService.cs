using System.Collections.Generic;
using System.Threading.Tasks;
using CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.Business.Abstract.Services
{
    public interface ICustomerService:IService<Customer>
    {
        public Task<Customer> GetByName(string name);

    }
}