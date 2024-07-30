using MagamentSystem.Application.DataTransferObject.Wares.Dealer;
using MagamentSystem.Application.Managers.Wares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Wares
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "dealerService")]
	[ApiController]
	[Authorize]
	public class DealerController : ControllerBase
	{
		private readonly IDealersManager _dealerManager;

		public DealerController(IDealersManager dealerManager)
		{
			_dealerManager = dealerManager;
		}
		[HttpPost("CreateDealer")]
		public async Task<IActionResult> CreateDealer([FromBody]CreateDealerRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response= await _dealerManager.CreateDealers(request);
			return Ok(response);
		}
		[HttpPut("UpdateDealer")]
		public async Task<IActionResult> UpdateDealer([FromBody]UpdateDealerRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _dealerManager.UpdateDealers(request);
			return Ok(response);
		}
		[HttpDelete("RemoveDealer")]
		public async Task<IActionResult> RemvoeDealer([FromQuery]RemoveDealerRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response= await _dealerManager.DeleteDealers(request);
			return Ok(response);
		}
		[HttpGet("DealerList")]
		public IActionResult GetAllDealers()
		{
			var response = _dealerManager.GetAllDealers();
			return Ok(response);
		}
		[HttpGet("AllDealerFilter")]
		public IActionResult GetAllDealerFilter([FromQuery]FilterDealerRequest request)
		{
			var response= _dealerManager.GetAllDealersFilter(request);
			return Ok(response);
		}
		[HttpGet("DealerFilter")]
		public IActionResult GetDealerFilter([FromQuery]FilterDealerRequest request)
		{
			var response = _dealerManager.GetDealersFilter(request);
			return Ok(response);
		}
		[HttpGet("DealerById{dealerId}")]
		public async Task<IActionResult> DealerById([FromRoute]int dealerId)
		{
			var response = await _dealerManager.GetDealersById(dealerId);
			return Ok(response);
		}


	}
}
