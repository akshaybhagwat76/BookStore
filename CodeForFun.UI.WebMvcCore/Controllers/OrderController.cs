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
	public class OrderController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IProductDetailsService _productDetailsService;
		private readonly ICategoryService _categoryService;
		private readonly IProductsToCustomer _productsToCustomer;

		public OrderController(IProductService productService, ICategoryService categoryService, IMapper mapper,
			IProductsToCustomer productsToCustomer, IProductDetailsService productDetailsService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_productsToCustomer = productsToCustomer;
			_productDetailsService = productDetailsService;

			_categoryService.GetListAsync();
			_productDetailsService.GetListAsync();
		}

		[HttpGet]
		[Route("getAll")]
		public List<OrderViewModel> Get()
		{
			return GetOrders(0, true);
		}
		// GET: api/Order
		[HttpGet]
		public List<OrderViewModel> Get(int id)
		{
			return GetOrders(id);
		}

		private List<OrderViewModel> GetOrders(int id, bool getAll = false)
		{
			var productsToCustomer = new List<ProductsToCustomer>();

			if (getAll)
			{
				productsToCustomer = _productsToCustomer.GetAllWithInclude(x => x.Customer, x => x.Product).Result;
			}
			else
			{
				productsToCustomer = _productsToCustomer.GetAllWithInclude(x => x.Customer, x => x.Product).Result.
								Where(x => x.ProductId == id && x.Customer != null).ToList();
			}
				
			var orders = new List<OrderViewModel>();

			if (productsToCustomer.Any())
			{
				foreach (var product in productsToCustomer)
				{
					orders.Add(new OrderViewModel
					{
						Name = product.Product.Name,
						CategoryName =_categoryService.GetAllWithInclude(x => x.Products).Result.Where(x=>x.Products.Where(y => y.Name == product.Product.Name) != null).FirstOrDefault().Name,
						DateRegister = product.Product.DateRegister,
						Description = product.Product.ProductDetail?.Description ?? null,
						IsActive = product.Product.IsActive,
						Code = product.Product.Code,
						UnitPrice = product.Product.UnitPrice.ToString(),
						NameOfEmployer = product.Customer?.Name,
						SurnameOfEmployer = product.Customer?.Surname
					});
				}
			}

			return orders;
		}


	}
}
