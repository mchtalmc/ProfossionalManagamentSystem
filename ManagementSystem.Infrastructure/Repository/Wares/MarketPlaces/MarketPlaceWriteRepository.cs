using MagamentSystem.Application.Repository.WaresRepository.MarketPlaces;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.MarketPlaces
{
	public class MarketPlaceWriteRepository : WriteRepository<MarketPlace>, IMarketPlaceWriteRepository
	{
		public MarketPlaceWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
