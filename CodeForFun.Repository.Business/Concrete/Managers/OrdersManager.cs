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
    public class OrdersManager : IOrdersService
    {
        private readonly IRepositoryWrapper _dal;

        public OrdersManager(IRepositoryWrapper dal)
        {
            _dal = dal;
        }

        public async Task<Orders> GetAsync(int id)
        {
            return await _dal.Orders.ReadAsync(p => p.Id == id);
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => { _dal.Orders.DeleteRange(ids.Select(id => new Orders { Id = Convert.ToInt16(id) }).ToList()); });
        }

        // DELETE ASYNC
        public async void DeleteAsync(Orders order)
        {
            await Task.Run(() => _dal.Orders.DeleteAsync(order));
        }


        public async Task<List<Orders>> GetAllWithInclude(params Expression<Func<Orders, object>>[] includeProperties)
        {
            return await _dal.Orders.GetAllWithInclude(includeProperties);
        }

        // ADD ASYNC
        public async void AddAsync(Orders entity)
        {
            await Task.Run(() => { _dal.Orders.CreateAsync(entity); });
        }

        // ADD RANGE ASYNC
        public async void AddRangeAsync(List<Orders> entities)
        {
            await Task.Run(() => { _dal.Orders.CreateRangeAsync(entities); });
        }
        // GET ALL ASYNC
        public async Task<List<Orders>> GetListAsync()
        {
            return await _dal.Orders.ReadListAsync();
        }


        //// ADD ASYNC
        //public async void AddAsync(Employee entity)
        //{
        //    await Task.Run(() => { _dal.Category.CreateAsync(entity); });
        //}

        //// ADD RANGE ASYNC
        //public async void AddRangeAsync(List<Category> entities)
        //{
        //    await Task.Run(() => { _dal.Category.CreateRangeAsync(entities); });
        //}


        //// UPDATE ASYNC
        //public async void UpdateAsync(Category entity)
        //{
        //    await Task.Run(() => { _dal.Employee.UpdateAsync(entity); });
        //}

        //// UPDATE RANGE ASYNC
        public async void UpdateRangeAsync(List<Orders> entities)
        {
            await Task.Run(() => { _dal.Orders.UpdateRangeAsync(entities); });
        }

        // UPDATE ASYNC
        public async void UpdateAsync(Orders entity)
        {
            await Task.Run(() => { _dal.Orders.UpdateAsync(entity); });
        }


        // DELETE RANGE ASYNC
        //public async void DeleteRangeAsync(IEnumerable<int> ids)
        //{
        //    await Task.Run(() => { _dal.Category.DeleteRange(ids.Select(id => new Category { Id = Convert.ToInt16(id) }).ToList()); });
        //}

        //public async Task<List<Category>> GetAllWithInclude(params Expression<Func<Category, object>>[] includeProperties)
        //{
        //    return await _dal.Category.GetAllWithInclude(includeProperties);
        //}
    }
}
