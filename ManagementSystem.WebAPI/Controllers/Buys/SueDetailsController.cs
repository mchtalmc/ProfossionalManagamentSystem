using MagamentSystem.Application.DataTransferObject.Buy.SueDetails;
using MagamentSystem.Application.Managers.Buy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Buys
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "sueDetailsService")]
	[ApiController]
	[Authorize]
	public class SueDetailsController : ControllerBase
	{
		private readonly ISueDetailManager _sueDetailManager;

		public SueDetailsController(ISueDetailManager sueDetailManager)
		{
			_sueDetailManager = sueDetailManager;
		}
		[HttpPost("CreateSueDetail")]
		public async Task<IActionResult> CreateSueDetail([FromBody]CreateSueDetailsRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response= await _sueDetailManager.CreateSueDetails(request);
			return Ok(response);
		}
		[HttpPut("UpdateSueDetail")]
		public async Task<IActionResult> UpdateSueDetail([FromBody]UpdateSueDetailsRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _sueDetailManager.UpdateSueDetails(request);
			return Ok(response);
		}
		[HttpDelete("RemoveSueDetail")]
		public async Task<IActionResult> RemoveSueDetail([FromQuery]RemoveSueDetailsRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response = await _sueDetailManager.DeleteSueDetails(request);
				return Ok(response);
		}
		[HttpGet("AllSueDetail")]
		public IActionResult AllSueDetaul()
		{
			var response = _sueDetailManager.GetAllSueDetails();
			return Ok(response);
		}
		[HttpGet("AllSueDetailsFilter")]
		public IActionResult AllSueDetailFilter([FromQuery]FilterSueDetailsRequest request)
		{
			var response = _sueDetailManager.GetAllSueDetailsFilter(request);
			return Ok(response);
		}
		[HttpGet("SueDetailFilter")]
		public IActionResult SueDetailFilter([FromQuery]FilterSueDetailsRequest request)
		{
			var response = _sueDetailManager.GetSueDetailsFilter(request);
			return Ok(response);
		}
		[HttpGet("SueById{sueDetailId}")]
		public async Task<IActionResult> SueById([FromRoute] int sueDetailId)
		{
			var response= await _sueDetailManager.GetSueDetailsById(sueDetailId);
			return Ok(response);
		}
	}
}
