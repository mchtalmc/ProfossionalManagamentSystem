using MagamentSystem.Application.Repository.WaresRepository.Categoryies;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.Categories
{
	public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
	{
		public CategoryWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
