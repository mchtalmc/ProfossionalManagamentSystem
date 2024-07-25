using ManagamentSystem.Core.Entities;
using System.Linq.Expressions;

namespace MagamentSystem.Application.Repository
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<bool> AddAsync(T entity);
		bool Update(T entity); //Soft Delete ıslemı yapılacak.
		bool Remove(T entity);

		Task<int> Save(); // contex'e baglanıp save islemi yapılacak.


	}
}
