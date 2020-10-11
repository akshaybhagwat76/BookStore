using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Concrete.Managers
{
	public class ProductsToCustomerManager : IProductsToCustomer
	{
        private readonly IRepositoryWrapper _dal;

        public ProductsToCustomerManager(IRepositoryWrapper dal)
        {
            _dal = dal;
        }


        //// GET ASYNC
        //public async Task<ProductsToCustomer> GetAsync(int id)
        //{
        //    return await _dal.ProductsToCustomers.ReadAsync(p => p.ProductsToCustomerId== id);
        //}
        // GET ASYNC
        public async Task<ProductsToCustomer> GetAsync(int id)
        {
            return await _dal.ProductsToCustomers.ReadAsync(p => p.ProductsToCustomerId == id);
        }

        // GET ALL ASYNC
        public async Task<List<ProductsToCustomer>> GetListAsync()
        {
            return await _dal.ProductsToCustomers.ReadListAsync();
        }


        // ADD ASYNC
        public async void AddAsync(ProductsToCustomer entity)
        {
            await Task.Run(() => { _dal.ProductsToCustomers.CreateAsync(entity); });
        }

        // ADD RANGE ASYNC
        public async void AddRangeAsync(List<ProductsToCustomer> entities)
        {
            await Task.Run(() => { _dal.ProductsToCustomers.CreateRangeAsync(entities); });
        }


        // UPDATE ASYNC
        public async void UpdateAsync(ProductsToCustomer entity)
        {
            await Task.Run(() => { _dal.ProductsToCustomers.UpdateAsync(entity); });
        }

        // UPDATE RANGE ASYNC
        public async void UpdateRangeAsync(List<ProductsToCustomer> entities)
        {
            await Task.Run(() => { _dal.ProductsToCustomers.UpdateRangeAsync(entities); });
        }


        // DELETE ASYNC
        public async void DeleteAsync(ProductsToCustomer productsToCustomer)
        {
            await Task.Run(() => { _dal.ProductsToCustomers.DeleteAsync(productsToCustomer); });
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => { _dal.ProductsToCustomers.DeleteRange(ids.Select(id => new ProductsToCustomer { ProductsToCustomerId = id }).ToList()); });
        }

        public async Task<List<ProductsToCustomer>> GetAllWithInclude(params Expression<Func<ProductsToCustomer, object>>[] includeProperties)
        {
            return await _dal.ProductsToCustomers.GetAllWithInclude(includeProperties);
        }
    }
}
