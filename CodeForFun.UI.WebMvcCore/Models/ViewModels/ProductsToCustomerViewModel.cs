using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
    public class ProductsToCustomerViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public virtual CustomerViewModel Customer { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}
