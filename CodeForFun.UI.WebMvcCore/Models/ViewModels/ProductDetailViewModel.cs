using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
	public class ProductDetailViewModel
	{
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ProductViewModel IdNavigation { get; set; }
    }
}
