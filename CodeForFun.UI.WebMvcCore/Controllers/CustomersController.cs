using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeForFun.UI.WebMvcCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
		private readonly ICustomerService _CustomerService;	

		public CustomersController(ICustomerService CustomerService)
		{
			_CustomerService = CustomerService;
		}

		// GET: api/Customer
		[HttpGet]
		[Route("GetAll")]
		public Task<List<Customer>> Get()
		{
			
			return _CustomerService.GetListAsync();
		}

		[HttpGet]
		public Task<Customer> Get(int id)
		{
			var Customer = _CustomerService.GetAsync(id);

			if (Customer == null)
				return null;

			return Customer;
		}

		// POST: api/Customer
		[HttpPost]
		public async Task<IActionResult> Post(Customer customer)

		{
			_CustomerService.AddAsync(customer);

			return Ok();
		}

		[HttpPut]
		public IActionResult Put([FromBody] Customer Customer)
		{
			if (Customer == null)
				return BadRequest("Customer is Null");

			var getProd = _CustomerService.GetAsync(Customer.Id);

			if (getProd != null)
			{
				_CustomerService.UpdateAsync(Customer);
			}

			return Ok();
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var getProd = _CustomerService.GetAsync(id);

			if (getProd.Result != null)
			{
				_CustomerService.DeleteAsync(getProd.Result);
			}

			return Ok();
		}
	}
}
