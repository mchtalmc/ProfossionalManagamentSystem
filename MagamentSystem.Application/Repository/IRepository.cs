using ManagamentSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagamentSystem.Application.Repository
{
	public interface IRepository<T> where T : BaseEntity
	{
		DbSet<T> Table { get; }
	}
}
