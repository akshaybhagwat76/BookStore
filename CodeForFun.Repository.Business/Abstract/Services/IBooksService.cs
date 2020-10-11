using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.Repository.Business.Abstract.Services
{
    public interface IBooksService : IService<Books>, IServiceForQueryable<Books>
    {
        public Task<Books> GetByName(string name);

    }
}
