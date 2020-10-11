using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Core
{
	public interface IGenereticRepository<T>:IEntityRepository<T>,IQueryableRepository<T> where T:class,new() 
	{
	}
}
