using Azure.Core;
using MagamentSystem.Application.DataTransferObject.User.Healt;
using MagamentSystem.Application.Managers.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "healthService")]
	[ApiController]
	[Authorize]
	public class HealtController : ControllerBase
	{
		private readonly IHealtManager _healtManager;

		public HealtController(IHealtManager healtManager)
		{
			_healtManager = healtManager;
		}
		[HttpPost("CreateHealtStatus")]
		public async Task<IActionResult> CreateHealtsSatus([FromBody]CreateHealtyRequest req)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			req.AddedBy = int.Parse(loginUserId);
			var response= await _healtManager.CreateHealtStatus(req);
			return Ok(response);
		}
		[HttpPut("UpdateHealtStatus")]
		public async Task<IActionResult> UpdateHealtStatus([FromBody]UpdateHealtyRequest req)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			req.ModifiedBy = int.Parse(loginUserId);
			var response = await _healtManager.UpdateHealtStatus(req);
				return Ok(response);
			
		}
		[HttpDelete("RemoveHealtStatus")]
		public async Task<IActionResult> RemoveHealtSatus([FromQuery]RemoveHealtyRequest req)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			req.RemovedBy = int.Parse(loginUserId);
			var response= await _healtManager.DeleteHealtStatus(req);
			return Ok(response);
		}
		[HttpGet("GetAllHealtStatus")]
		public IActionResult GetAllHealtStatus()
		{
			var response= _healtManager.GetAllHealtStatus();
			return Ok(response);
		}
		[HttpGet("GetAllHealtStatusFilter")]
		public IActionResult GetAllHealtStatusFilter([FromQuery]FilterHealtyRequest req)
		{
			var response= _healtManager.GetAllHealtStatusFilter(req);
			return Ok(response);
		}
		[HttpGet("GetHealtStatusFilter")]
		public IActionResult GetHealtStatusFilter([FromQuery] FilterHealtyRequest req)
		{
			var response = _healtManager.GetHealtStatusFilter(req);
			return Ok(response);
		}
	}
}
