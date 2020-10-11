using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.Repository.Entities.Concrete.CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Concrete.Managers
{
	public class ProductManager : IProductService
	{
        private readonly IRepositoryWrapper _dal;

        public ProductManager(IRepositoryWrapper dal)
        {
            _dal = dal;
        }


        // GET ASYNC
        public async Task<Product> GetAsync(int id)
        {
            return await _dal.Product.ReadAsync(p => p.Id == id);
        }

        // GET ALL ASYNC
        public async Task<List<Product>> GetListAsync()
        {
            return await _dal.Product.ReadListAsync();
        }


        // ADD ASYNC
        public async void AddAsync(Product entity)
        {
            await Task.Run(() => { _dal.Product.CreateAsync(entity); });
        }

        // ADD RANGE ASYNC
        public async void AddRangeAsync(List<Product> entities)
        {
            await Task.Run(() => { _dal.Product.CreateRangeAsync(entities); });
        }


        // UPDATE ASYNC
        public async void UpdateAsync(Product entity)
        {
            await Task.Run(() => { _dal.Product.UpdateAsync(entity); });
        }

        // UPDATE RANGE ASYNC
        public async void UpdateRangeAsync(List<Product> entities)
        {
            await Task.Run(() => { _dal.Product.UpdateRangeAsync(entities); });
        }


        // DELETE ASYNC
        public async void DeleteAsync(Product entity)
        {
            await Task.Run(() =>  _dal.Product.DeleteAsync(entity));
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => { _dal.Product.DeleteRange(ids.Select(id => new Product { Id = id }).ToList()); });
        }
        public async Task<List<Product>> GetAllWithInclude(params Expression<Func<Product, object>>[] includeProperties)
        {
            return await _dal.Product.GetAllWithInclude(includeProperties);
        }

        public async Task<Product> GetByName(string name)

        {
            return await _dal.Product.Get(x => x.Name == name);

        }
    }
}
