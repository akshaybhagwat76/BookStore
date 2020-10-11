using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.UI.WebMvcCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeForFun.UI.WebMvcCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
    {
        
		private readonly IBooksService _BookService;
		private readonly IMapper _mapper;
		public BooksController(IBooksService BookService, IMapper mapper, IProductService productService)
		{
			_BookService = BookService;
			_mapper = mapper;
		}

		// GET: api/Category
		[HttpGet]
		[Route("GetAll")]
		public async Task<IEnumerable<BooksViewModel>> Get()
		{
            try
            {
                var bools = await _BookService.GetListAsync();
                return _mapper.Map<IEnumerable<BooksViewModel>>(bools.ToList());
            }
            catch (Exception ex)
            {

                throw;
            }
		}

		[HttpGet]
		[Route("get/{id}")]
		public async Task<Books> Get(int id)
		{
			var Book = await _BookService.GetAsync(id);

			if (Book == null)
				return null;

			return Book;
		}

		[HttpGet]
		[Route("GetAllWithParents")]
		public async Task<IEnumerable<CategoryViewModelWithParent>> GetAllWithParents()
		{
			try
			{
				var o = await _BookService.GetListAsync();
				var books = _mapper.Map<IEnumerable<CategoryViewModelWithParent>>(await _BookService.GetListAsync());

				return books;
			}
			catch (Exception)
			{
				throw;
			}
		}


		// POST: api/Books
		[HttpPost]
		[Route("post")]
		public async Task<IActionResult> Post(BooksViewModel book)
		{

			if (!string.IsNullOrEmpty(book.BookName))
			{
				var isExist = await _BookService.GetByName(book.BookName);

                if (isExist!=null && isExist.Id > 0)
                {
					return BadRequest("Book already exists");
                }
				var newBook = new Books()
				{
					BookName = book.BookName,
					CreatedBy = book.CreatedBy,
					CreatedDate = DateTime.UtcNow,
					Price = book.Price,
				};

				_BookService.AddAsync(newBook);

				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete]
		[Route("delete/{id}")]

		public IActionResult Delete(int id)
		{
			
			var getProd = _BookService.GetAsync(id);

			if (getProd.Result != null)
			{
				_BookService.DeleteAsync(getProd.Result);
			}

			return Ok();
		}
	}
}
