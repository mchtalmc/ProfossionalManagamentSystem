using MagamentSystem.Application.DataTransferObject.Buy.Contractor;
using MagamentSystem.Application.Managers.Buy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Buys
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "contractorService")]
	[ApiController]
	public class ContractorController : ControllerBase
	{
		private readonly IContractorManager _contratrocManager;

		public ContractorController(IContractorManager contratrocManager)
		{
			_contratrocManager = contratrocManager;
		}
		[HttpPost("CreateContractor")]
		public async Task<IActionResult> CreateContractor([FromBody]CreateContractorRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response= await _contratrocManager.CreateContractor(request);
			return Ok(response);
		}
		[HttpPut("UpdateContractor")]
		public async Task<IActionResult> UpdateContractor([FromBody]UpdateContractorRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _contratrocManager.UpdateContractor(request);
			return Ok(response);
		}
		[HttpDelete("RemoveContractor")]
		public async Task<IActionResult> RemoveContractor([FromQuery]RemoveContractorRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response = await _contratrocManager.DeleteContractor(request);
			return Ok(response);
		}
		[HttpGet("AllContractor")]
		public IActionResult AllContractor()
		{
			var response = _contratrocManager.GetAllContractor();
			return Ok(response);
		}
		[HttpGet("AllContractorFilter")]
		public IActionResult AllContractorFilter([FromQuery]FilterContractorRequest request)
		{
			var response = _contratrocManager.GetAllContractorFilter(request);
			return Ok(response);
		}
		[HttpGet("ContractorFilter")]
		public IActionResult ContractorFilter([FromQuery]FilterContractorRequest request)
		{
			var response = _contratrocManager.GetContractorFilter(request);
			return Ok(response);
		}
		[HttpGet("ContractorById{contractorId}")]
		public async Task<IActionResult> ContractorById([FromRoute]int contractorId)
		{
			var response = await _contratrocManager.GetContractorById(contractorId);
			return Ok(response);
		}
	}
}
