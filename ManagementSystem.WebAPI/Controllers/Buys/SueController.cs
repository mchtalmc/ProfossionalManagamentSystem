using MagamentSystem.Application.DataTransferObject.Buy.Sue;
using MagamentSystem.Application.Managers.Buy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Buys
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "sueService")]
	[ApiController]
	[Authorize]
	public class SueController : ControllerBase
	{
		private readonly ISueManager _sueManager;

		public SueController(ISueManager sueManager)
		{
			_sueManager = sueManager;
		}

		[HttpPost("CreateSue")]
		public async Task<IActionResult> CreateSue([FromBody] CreateSueRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response = await _sueManager.CreateSue(request);
			return Ok(response);
		}
		[HttpPut("UpdateSue")]
		public async Task<IActionResult> UpdateSue([FromBody] UpdateSueRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _sueManager.UpdateSue(request);
			return Ok(response);
		}
		[HttpDelete("RemoveSue")]
		public async Task<IActionResult> RemoveSue([FromQuery] RemoveSueRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response = await _sueManager.DeleteSue(request);
			return Ok(response);
		}
		[HttpGet("AllSue")]
		public IActionResult AllSue()
		{
			var response = _sueManager.GetAllSue();
			return Ok(response);
		}
		[HttpGet("AllSueFilter")]
		public IActionResult AllSueFilter([FromQuery]FilterSueRequest request)
		{
			var response = _sueManager.GetAllSueFilter(request);
			return Ok(response);
		}
		[HttpGet("SueFilter")]
		public IActionResult SueFilter([FromQuery,]FilterSueRequest request)
		{
			var response = _sueManager.GetSueFilter(request); 
			return Ok(response);
		}
		[HttpGet("SueById{sueId}")]
		public async Task<IActionResult> SueById([FromRoute]int sueId)
		{
			var response= await _sueManager.GetSueById(sueId);
			return Ok(response);
		}
	
	}
}
