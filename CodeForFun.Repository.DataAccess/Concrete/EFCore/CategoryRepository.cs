using CodeForFun.Core;
using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.DataAccess.EFCore
{
	public class CategoryRepository: GenereticRepository<Category,RepositoryContext>,ICategory
	{
		public CategoryRepository(RepositoryContext context) : base(context) { }
	}
}
