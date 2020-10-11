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
	public class CategoryManager : ICategoryService
	{
        private readonly IRepositoryWrapper _dal;

        public CategoryManager(IRepositoryWrapper dal)
        {
            _dal = dal;
        }


        // GET ASYNC
        public async Task<Category> GetAsync(int id)
        {
            return await _dal.Category.ReadAsync(p => p.Id == id);
        }

        // GET ALL ASYNC
        public async Task<List<Category>> GetListAsync()
        {
            return await _dal.Category.ReadListAsync();
        }


        // ADD ASYNC
        public async void AddAsync(Category entity)
        {
            await Task.Run(() => {  _dal.Category.CreateAsync(entity); });
        }

        // ADD RANGE ASYNC
        public async void AddRangeAsync(List<Category> entities)
        {
            await Task.Run(() => { _dal.Category.CreateRangeAsync(entities); });
        }


        // UPDATE ASYNC
        public async void UpdateAsync(Category entity)
        {
            await Task.Run(() => { _dal.Category.UpdateAsync(entity); });
        }

        // UPDATE RANGE ASYNC
        public async void UpdateRangeAsync(List<Category> entities)
        {
            await Task.Run(() => { _dal.Category.UpdateRangeAsync(entities); });
        }


        // DELETE ASYNC
        public async void DeleteAsync(Category category)
        {
            await Task.Run(() =>  _dal.Category.DeleteAsync(category));
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => { _dal.Category.DeleteRange(ids.Select(id => new Category { Id = Convert.ToInt16(id) }).ToList()); });
        }

        public async Task<List<Category>> GetAllWithInclude(params Expression<Func<Category, object>>[] includeProperties)
        {
            return await _dal.Category.GetAllWithInclude(includeProperties);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _dal.Category.Get(x => x.Name == name);
        }
    }
}
