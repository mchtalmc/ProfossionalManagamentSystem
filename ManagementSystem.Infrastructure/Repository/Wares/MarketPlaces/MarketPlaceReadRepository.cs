using MagamentSystem.Application.Repository.WaresRepository.MarketPlaces;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.MarketPlaces
{
	public class MarketPlaceReadRepository : ReadRepository<MarketPlace>, IMarketPlaceReadRepository
	{
		public MarketPlaceReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
