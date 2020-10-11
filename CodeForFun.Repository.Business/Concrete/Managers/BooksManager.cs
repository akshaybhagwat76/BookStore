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
    public class BooksManager : IBooksService
    {
        private readonly IRepositoryWrapper _dal;

        public BooksManager(IRepositoryWrapper dal)
        {
            _dal = dal;
        }

        public async Task<Books> GetAsync(int id)
        {
            return await _dal.Books.ReadAsync(p => p.Id == id);
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => { _dal.Books.DeleteRange(ids.Select(id => new Books { Id = Convert.ToInt16(id) }).ToList()); });
        }

        // DELETE ASYNC
        public async void DeleteAsync(Books book)
        {
            await Task.Run(() => _dal.Books.DeleteAsync(book));
        }


        public async Task<List<Books>> GetAllWithInclude(params Expression<Func<Books, object>>[] includeProperties)
        {
            return await _dal.Books.GetAllWithInclude(includeProperties);
        }

        public async Task<Books> GetByName(string name)
        {
            return await _dal.Books.Get(x => x.BookName == name);
        }

        // ADD ASYNC
        public async void AddAsync(Books entity)
        {
            await Task.Run(() => { _dal.Books.CreateAsync(entity); });
        }

        // ADD RANGE ASYNC
        public async void AddRangeAsync(List<Books> entities)
        {
            await Task.Run(() => { _dal.Books.CreateRangeAsync(entities); });
        }
        // GET ALL ASYNC
        public async Task<List<Books>> GetListAsync()
        {
            return await _dal.Books.ReadListAsync();
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
        public async void UpdateRangeAsync(List<Books> entities)
        {
            await Task.Run(() => { _dal.Books.UpdateRangeAsync(entities); });
        }

        // UPDATE ASYNC
        public async void UpdateAsync(Books entity)
        {
            await Task.Run(() => { _dal.Books.UpdateAsync(entity); });
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
