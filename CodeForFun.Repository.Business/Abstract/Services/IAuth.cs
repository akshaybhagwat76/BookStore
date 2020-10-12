using CodeForFun.UI.WebMvcCore.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.Business.Abstract.Services
{
	public interface IAuth
	{
		User Login(string username, string password);
		string Register(User ss, string password,string roleName);

	}
}
