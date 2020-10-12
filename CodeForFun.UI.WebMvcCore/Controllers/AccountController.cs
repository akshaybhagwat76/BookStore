using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.UI.WebMvcCore.Models;
using CodeForFun.UI.WebMvcCore.Models.ViewModels;
using CodeForFun.UI.WebMvcCore.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CodeForFun.UI.WebMvcCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAuth _auth;
        private readonly IJwtHandler jwtHandler;

        public AccountController(IAuth auth, IJwtHandler jwtHandler)
        {
            _auth = auth;
            this.jwtHandler = jwtHandler;

        }

        // POST: api/Account
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post([FromBody] UserForRegisterViewModel userForRegister)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var user = new User
            {
                Email = userForRegister.Email,
                Password = userForRegister.Password,
                Name = userForRegister.Name,
                Surname = userForRegister.Surname,
            };

            try
            {
                var isReg = _auth.Register(user, user.Password,userForRegister.RoleName);

                if (isReg == "")
                    throw new Exception();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            var token = _auth.Login(user.Email, user.Password);
            string roleName = token.Role.Name;
            Guid userId = token.UserID;
            string name = token.Name;
            //return Ok(new
            //{
            //    token = tokenHandler.WriteToken(token)
            //});
            return Ok(jwtHandler.Create(userId, roleName, name));

        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserForLoginViewModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = _auth.Login(model.Email, model.Password);

            if (token == null)
                return Unauthorized();


            string roleName = token.Role.Name;
            Guid userId = token.UserID;
            string name = token.Name;

            //return Ok(new
            //{
            //    token = tokenHandler.WriteToken(token)
            //});
            return Ok(jwtHandler.Create(userId, Enum.GetName(typeof(Utility.Role), roleName), name));
        }
    }
}
