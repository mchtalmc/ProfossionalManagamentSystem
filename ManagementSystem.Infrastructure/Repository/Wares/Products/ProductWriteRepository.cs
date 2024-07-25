using MagamentSystem.Application.Repository.WaresRepository.Products;

namespace ManagementSystem.Infrastructure.Repository.Wares.Products
{
	public class ProductWriteRepository : WriteRepository<ManagamentSystem.Core.Entities.Wares.Product>, IProductWriteRepository
	{
		public ProductWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
