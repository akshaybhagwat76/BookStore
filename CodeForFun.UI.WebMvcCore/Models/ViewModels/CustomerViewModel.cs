using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
	public class CustomerViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<ProductsToCustomerViewModel> ProductsToCustomers { get; set; }
    }
}
