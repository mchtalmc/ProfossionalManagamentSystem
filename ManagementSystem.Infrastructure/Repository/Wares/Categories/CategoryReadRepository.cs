using MagamentSystem.Application.Repository.WaresRepository.Categoryies;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.Categories
{
	public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
	{
		public CategoryReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
