using MagamentSystem.Application.DataTransferObject.Wares.MarketPlace;
using MagamentSystem.Application.Managers.Wares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Wares
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "marketPlaceService")]
	[ApiController]
	public class MarketPlaceController : ControllerBase
	{
		private readonly IMarketPlaceManager _marketPlaceManager;

		public MarketPlaceController(IMarketPlaceManager marketPlaceManager)
		{
			_marketPlaceManager = marketPlaceManager;
		}
		[HttpPost("CreateMarketPlace")]
		public async Task<IActionResult> CreateMarketPlace([FromBody] CraeteMarketPlaceRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response= await _marketPlaceManager.CreateMarketPlace(request);
			return Ok(response);
		}
		[HttpPut("UpdateMarketPlace")]
		public async Task<IActionResult> UpdateMarketPlace([FromBody]UpdateMarketPlaceRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response= await _marketPlaceManager.UpdateMarketPlace(request);
			return Ok(response);
		}
		[HttpDelete("RemoveMarketPlace")]
		public async Task<IActionResult> RemoveMarketPlace([FromQuery]RemoveMarketPlaceRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response = await _marketPlaceManager.DeleteMarketPlace(request);
			return Ok(response);
		}
		[HttpGet("GetAllMarketPlace")]
		public IActionResult GetAllMarketPlace()
		{
			var response = _marketPlaceManager.GetAllMarketPlace();
			return Ok(response);
		}
		[HttpGet("AllMarketPlaceFilter")]
		public IActionResult AllMarketPlaceFilter([FromQuery]FilterMarketPlaceRequest request)
		{
			var response= _marketPlaceManager.GetAllMarketPlaceFilter(request);
			return Ok(response);
		}
		[HttpGet("MarketPlaceFilter")]
		public IActionResult MarketPlaceFilter([FromQuery]FilterMarketPlaceRequest request)
		{
			var response = _marketPlaceManager.GetAllMarketPlaceFilter(request);
			return Ok(response);
		}
		[HttpGet("MarketPlaceById{marketPlaceId}")]
		public async Task<IActionResult> MarketPlaceById([FromRoute]int marketPlaceId)
		{
			var response = await _marketPlaceManager.GetMarketPlaceById(marketPlaceId);
			return Ok(response);
		}
	}
}
