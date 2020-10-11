using CodeForFun.Core.Entities;
using CodeForFun.Repository.Entities.Concrete;
using System;

namespace CodeForFun.UI.WebMvcCore.Models
{
    public class User:IEntity
    {
        public Guid UserID { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
