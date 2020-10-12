using CodeForFun.Repository.Entities.Concrete;
namespace CodeForFun.Repository.Business.Abstract.Services
{
    public interface IOrdersService : IService<Orders>, IServiceForQueryable<Orders>
    {
    }
}

