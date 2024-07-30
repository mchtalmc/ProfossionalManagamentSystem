using Azure.Core;
using MagamentSystem.Application.DataTransferObject.User.Military;
using MagamentSystem.Application.Managers.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "militaryService")]
	[ApiController]
	[Authorize]
	public class MilitaryController : ControllerBase
	{
		private readonly IMilitaryManager _militaryManager;

		public MilitaryController(IMilitaryManager militaryManager)
		{
			_militaryManager = militaryManager;
		}

		[HttpPost("CreateMilitaryStatus")]
		public async Task<IActionResult> CreateMilitaryStatus([FromBody]CreateMilitaryRequest req)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			req.AddedBy = int.Parse(loginUserId);
			var response= await _militaryManager.CreateMilitaryStatus(req);
			return Ok(response);
		}
		[HttpPut("UpdateMilitaryStatus")]
		public async Task<IActionResult> UpdateMilitaryStatus([FromBody]UpdateMilitaryRequest req)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			req.ModifiedBy = int.Parse(loginUserId);
			var response = await _militaryManager.UpdateMilitaryStatus(req);
			return Ok(response);
		}
		[HttpDelete("RemoveMilitaryStatus")]
		public async Task<IActionResult> RemoveMilitaryStatus([FromQuery]RemoveMilitaryRequest req)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			req.RemovedBy = int.Parse(loginUserId);
			var response = await _militaryManager.DeleteMilitaryStatus(req);
			return Ok(response);
		}
		[HttpGet("GetAllMilitaryStatus")]
		public IActionResult GetAllMilitaryStatus()
		{
			var response = _militaryManager.GetAllMilitaryStatus();
			return Ok(response);
		}
		[HttpGet("GetAllMilitaryStatusFilter")]
		public IActionResult GetAllMilitaryStatusFilter([FromQuery]FilterMilitaryRequest req)
		{
			var response = _militaryManager.GetAllFilterMilitaryStatus(req);
			return Ok(response);
		}
		[HttpGet("GetMilitaryStatusFilter")]
		public IActionResult GetMilitaryStatusFilter([FromQuery]FilterMilitaryRequest req)
		{
			var response = _militaryManager.GetMilitaryStatutsFilter(req);
			return Ok(response);
		}
		[HttpGet("GetMilitaryStatusById{id}")]
		public async Task<IActionResult> GetMilitaryStatusById([FromRoute]int id)
		{
			var response = await _militaryManager.GetMilitaryStatusById(id);
			return Ok(response);
		}
	}
}
