
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.UI.WebMvcCore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CodeForFun.Repository.Business.Concrete.Managers
{
	public class AuthManager : IAuth
	{
		private IRepositoryWrapper _repo;
		private readonly IConfiguration _config;

		private RepositoryContext _context;

		public AuthManager(IRepositoryWrapper reposWrapper, IConfiguration config, RepositoryContext context)
		{
			_repo = reposWrapper;
			_context = context;
			_config = config;
		}

		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != passwordHash[i])
						return false;
				}
			}
			return true;
		}

		private void CreatePasswordHast(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			}
		}

		public SecurityToken Login(string username, string password)
		{
				var p = _repo.User.Get(x => x.Email == username);

			if (p == null)
				return null;
			if (!VerifyPasswordHash(password, p.Result.PasswordHash, p.Result.PasswordSalt))
				return null;
			var claims = new List<Claim>
		  {
				new Claim(ClaimTypes.Name,p.Result.Email)
		   };



			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);



			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddHours(1),
				SigningCredentials = creds
			};
			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return token;
		}

		public string Register(User ss, string password)
		{
			var p = _repo.User.Get(x => x.Email == ss.Email);

			if (p!=null && p.Result == null)
			{
				try
				{
					ss.UserID = Guid.NewGuid();

					CreatePasswordHast(password, out byte[] passwordHash, out byte[] passwordSalt);
					ss.PasswordHash = passwordHash;
					ss.PasswordSalt = passwordSalt;
					ss.RoleId = _repo.User.GetUserRole().RoleID;

					_repo.User.Create(ss);


				}
				catch (Exception ex) { throw ex; }

				return ss.Email;
			}

			return "";
		}

	}
}
