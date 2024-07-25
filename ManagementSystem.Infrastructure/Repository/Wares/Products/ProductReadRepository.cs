using MagamentSystem.Application.Repository.WaresRepository.Products;

namespace ManagementSystem.Infrastructure.Repository.Wares.Products
{
	public class ProductReadRepository : ReadRepository<ManagamentSystem.Core.Entities.Wares.Product>, IProductReadRepository
	{
		public ProductReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
