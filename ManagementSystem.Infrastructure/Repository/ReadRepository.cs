using MagamentSystem.Application.Repository;
using ManagamentSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ManagementSystem.Infrastructure.Repository
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
		private readonly ManagamentContext _context;

		public ReadRepository(ManagamentContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll()
		=> Table;

		public IQueryable<T> GetAllFilter(Expression<Func<T, bool>> predicate)
		{
			var value = Table.Where(predicate);
			return value;
		}

		public async Task<T> GetSingleById(int id)
		{
			var value = await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
			return value;
		}

		public async Task<T> GetSingleFilter(Expression<Func<T, bool>> predicate)
		{
			var value = await Table.Where(predicate).SingleOrDefaultAsync();
			return value;
		}
	}
}
