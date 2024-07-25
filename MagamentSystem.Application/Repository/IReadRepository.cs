using ManagamentSystem.Core.Entities;
using System.Linq.Expressions;

namespace MagamentSystem.Application.Repository
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetAllFilter(Expression<Func<T, bool>> predicate);
		Task<T> GetSingleFilter(Expression<Func<T, bool>> predicate);
		Task<T> GetSingleById(int id);
	}
}
