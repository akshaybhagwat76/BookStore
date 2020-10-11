using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
	public class ProductViewModel
	{
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime DateRegister { get; set; }
        public bool IsActive { get; set; }
        public short CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
