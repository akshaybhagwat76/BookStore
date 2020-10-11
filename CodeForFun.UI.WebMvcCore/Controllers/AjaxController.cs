using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeForFun.Repository.Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeForFun.UI.WebMvcCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AjaxController : ControllerBase
    {
		private readonly IProductDetailsService _productDetailService;
		private readonly IProductService _productService;

		private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;

		public AjaxController(IProductDetailsService productDetailService, IProductService productService, ICategoryService categoryService, IMapper mapper)
		{
			_productDetailService = productDetailService;
			_categoryService = categoryService;
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult Get(string text)
		{
			return Ok(text);
		}

	}
}