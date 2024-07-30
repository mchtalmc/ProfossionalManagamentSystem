using MagamentSystem.Application.DataTransferObject.User.Experience;
using MagamentSystem.Application.Managers.User;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "experienceService")]
	[ApiController]
	public class ExperienceController : ControllerBase
	{
		private readonly IExperienceManger _experienceManager;

		public ExperienceController(IExperienceManger experienceManager)
		{
			_experienceManager = experienceManager;
		}
		[HttpPost("CreateExperince")]
		public async Task<IActionResult> CreateExperience([FromBody]CreateExperienceRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response= await _experienceManager.CreateExperience(request);
			return Ok(response);
		}
		[HttpPut("UpdateExperience")]
		public async Task<IActionResult> UpdateExperience([FromBody]UpdateExperienceRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _experienceManager.UpdateExperience(request);
			return Ok(response);
		}
		[HttpDelete("RemoveExperience")]
		public async Task<IActionResult> RemoveExperience([FromQuery]RemoveExperienceRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response= await _experienceManager.DeleteExperience(request);
			return Ok(response);
		}
		[HttpGet("GetAllExperience")]
		public IActionResult GetAllExperience()
		{
			var response= _experienceManager.GetAllExperience();
			return Ok(response);
		}
		[HttpGet("GetAllExperienceFilter")]
		public IActionResult GetAllExperienceFilter([FromQuery]FilterExperienceRequest req)
		{
			var response= _experienceManager.GetAllExperienceFilter(req);
			return Ok(response);
		}
		[HttpGet("GetExperienceFilter")]
		public IActionResult GetExperienceFilter([FromQuery]FilterExperienceRequest req)
		{
			var response= _experienceManager.GetExperienceFilter(req);
			return Ok(response);
		}
		[HttpGet("GetExperienceById{id}")]
		public async Task<IActionResult> GetExperinceById([FromRoute]int id)
		{
			var response = await _experienceManager.GetExperienceById(id);
			return Ok(response);
		}

	}
}
