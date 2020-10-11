using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.UI.WebMvcCore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeForFun.UI.WebMvcCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public CategoryController(ICategoryService CategoryService, IMapper mapper,IProductService productService)
		{
			_categoryService = CategoryService;
			_productService = productService;

			_mapper = mapper;
		}

		// GET: api/Category
		[HttpGet]
		[Route("GetAll")]
		public async Task<IEnumerable<CategoryViewModel>> Get()
		{
			var categories = await _categoryService.GetListAsync();
			return _mapper.Map<IEnumerable<CategoryViewModel>>(categories.Where(x => x.Parent == null));
		}

		[HttpGet]
		public Task<Category> Get(int id)
		{
			var Category = _categoryService.GetAsync(id);

			if (Category == null)
				return null;

			return Category;
		}

		[HttpGet]
		[Route("GetAllWithParents")]
		public async Task<IEnumerable<CategoryViewModelWithParent>> GetAllWithParents()
		{
			try
			{
				var o = await _categoryService.GetListAsync();
				var categories = _mapper.Map<IEnumerable<CategoryViewModelWithParent>>(await _categoryService.GetListAsync());

				return categories;
			}
			catch (Exception)
			{
				throw;
			}
		}


		// POST: api/Category
		[HttpPost]
		public IActionResult Post([FromBody] Category Category)
		{
			_categoryService.AddAsync(Category);

			return Ok();
		}

		[HttpPut]
		[HttpPut]
		public IActionResult Put([FromBody] CategoryViewModelWithParent category)
		{
			if (category == null)
				return BadRequest("Category is Null");

			Category element = _categoryService.GetAsync(category.Id).Result;
			element.Name = category.Name;
			if (category.ParentName != null)	
			{
				Category parent = _categoryService.GetByName(category.ParentName).Result;
				element.ParentId = parent.Id;

			}

			_categoryService.UpdateAsync(element);

			return Ok();
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var getProduts = _productService.GetListAsync().Result.Where(x => x.CategoryId == id);
			if (getProduts.Count() > 0)
			{
				foreach (var item in getProduts)
				{
					_productService.DeleteAsync(item);

				}
			}


			var getChild = _categoryService.GetListAsync().Result.Where(x => x.ParentId == id);
			if (getChild.Count() > 0)
			{
				foreach (var item in getChild)
				{
					_categoryService.DeleteAsync(item);

				}
			}
			var getProd = _categoryService.GetAsync(id);

			if (getProd.Result != null)
			{
				_categoryService.DeleteAsync(getProd.Result);
			}

			return Ok();
		}
	}
}
