using CodeForFun.Core;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.UI.WebMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Abstract
{
	public interface IUser:IGenereticRepository<User>
	{
		public Role GetUserRole();
		public bool CheckRole(string username, string role);

	}
}
