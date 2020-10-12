using System;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
	public class UserForRegisterViewModel
	{
		public string Email { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string Surname { get; set; }
        public String RoleName{ get; set; }
    }
}
