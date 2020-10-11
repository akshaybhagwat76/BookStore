using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
	public class OrderViewModel
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string UnitPrice { get; set; }
		public DateTime DateRegister { get; set; }
		public bool IsActive { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public string NameOfEmployer { get; set; }
		public string SurnameOfEmployer { get; set; }

	}
}
