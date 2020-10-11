using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;
using CodeForFun.UI.WebMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Concrete.EFCore
{
    public class UserRepository : GenereticRepository<User, RepositoryContext>, IUser
    {
        private RepositoryContext _context;

        public UserRepository(RepositoryContext context) : base(context) {
            _context = context;


        }
        public bool CheckRole(string username, string role)
        {
            var p = _context.Users.SingleOrDefault(x => x.Name == username && x.Role.Name == role);
            return p == null ? false : true;
        }

        public Role GetUserRole()
        {
            return _context.Roles.Where(x => x.Name == "User").FirstOrDefault();
        }

    }
}
