using MagamentSystem.Application.DataTransferObject.User.Education;
using MagamentSystem.Application.Managers.User;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "educationService")]
	[ApiController]
	public class EducationController : ControllerBase
	{
		private readonly IEducationManager _educationManager;

		public EducationController(IEducationManager educationManager)
		{
			_educationManager = educationManager;
		}
		[HttpPost("CreateEducationInformation's")]
		public async Task<IActionResult> CreateEducationInfo([FromBody] CreateEducationRequest req)
		{
			var response = await _educationManager.CreateEducation(req);
			return Ok(response);
		}
		[HttpPut("UpdateEducationInformation's")]
		public async Task<IActionResult> UpdateEducationInfo([FromBody] UpdateEducationRequest req)
		{
			var response = await _educationManager.UpdateEducation(req);
			return Ok(response);
		}
		[HttpDelete("RemoveEducationInfo")]
		public async Task<IActionResult> RemoveEducationInfo([FromQuery]RemoveEducationRequest req)
		{
			var response = await _educationManager.DeleteEducation(req);
			return Ok(response);
		}
		[HttpGet("GetAllEducationInfo")]
		public IActionResult GetAllEducationInfo()
		{
			var response = _educationManager.GetAllEducation();
			return Ok(response);
		}
		[HttpGet("FilterAllEducationInfo")]
		public IActionResult GetAllEducationInfoFilter([FromQuery] FilterEducationRequest req)
		{
			var response = _educationManager.GetAllEducationFilter(req);
			return Ok(response);
		}
		[HttpGet("FilterEducationInfo")]
		public IActionResult GetEducationInfoFilter([FromQuery]FilterEducationRequest req)
		{
			var response = _educationManager.GetEducationFilter(req);
			return Ok(response);
		}
		[HttpGet("GetEducationInfoById{id}")]
		public async Task<IActionResult> GetEducationInfoById([FromRoute]int id)
		{
			var response = await _educationManager.GetEducationById(id);
			return Ok(response);
		}
		



	}
}
