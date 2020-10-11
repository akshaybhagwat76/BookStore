using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.Business.Concrete.Managers
{
    public class CustomerManager : ICustomerService
    {
        private readonly IRepositoryWrapper _dal;

        public CustomerManager(IRepositoryWrapper dal)
        {
            _dal = dal;
        }

        public async Task<Customer> GetByName(string name)
        {
            return await _dal.Customer.Get(x => x.Name == name);
        }
        // GET ASYNC
        public async Task<Customer> GetAsync(int id)
        {
            return await _dal.Customer.ReadAsync(p => p.Id == id);
        }

        // GET ALL ASYNC
        public async Task<List<Customer>> GetListAsync()
        {
            return await _dal.Customer.ReadListAsync();
        }


        // ADD ASYNC
        public async void AddAsync(Customer entity)
        {
            await Task.Run(() => { _dal.Customer.CreateAsync(entity); });
        }

        // ADD RANGE ASYNC
        public async void AddRangeAsync(List<Customer> entities)
        {
            await Task.Run(() => { _dal.Customer.CreateRangeAsync(entities); });
        }


        // UPDATE ASYNC
        public async void UpdateAsync(Customer entity)
        {
            await Task.Run(() => { _dal.Customer.UpdateAsync(entity); });
        }

        // UPDATE RANGE ASYNC
        public async void UpdateRangeAsync(List<Customer> entities)
        {
            await Task.Run(() => { _dal.Customer.UpdateRangeAsync(entities); });
        }


        // DELETE ASYNC
        public async void DeleteAsync(Customer customer)
        {
            await Task.Run(() =>  _dal.Customer.DeleteAsync(customer));
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => { _dal.Customer.DeleteRange(ids.Select(id => new Customer{Id = id}).ToList()); });
        }
    }
}