using CodeForFun.Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Abstract.Services
{
    public interface IRoleService : IService<Role>
    {
        public Task<Role> GetByName(string name);
    }
}
