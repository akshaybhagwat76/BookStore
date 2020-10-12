using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.DataAccess.EFCore
{
	public class BooksRepository : GenereticRepository<Books, RepositoryContext>, IBooks
	{
		public BooksRepository(RepositoryContext context) : base(context) { }
	}
}
