using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.Managers.Buy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Buys
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "contractInfoService")]
	[ApiController]
	[Authorize]
	public class ContractInfoController : ControllerBase
	{
		private readonly IContractInfoManager _contractInfoManager;

		public ContractInfoController(IContractInfoManager contractInfoManager)
		{
			_contractInfoManager = contractInfoManager;
		}
		[HttpPost("CreateContractInfo")]
		
		public async Task<IActionResult> CreateContractInfo([FromBody]CreateContractInfoRequest request)
		{
			var loginUserId= User?.FindFirst("id")?.Value;
			request.AddedBy=int.Parse(loginUserId);
			var response= await _contractInfoManager.CreateContractInfo(request);
			return Ok(response);
		}
		[HttpPut("UpdateContractInfo")]
		public async Task<IActionResult> UpdateContractInfo([FromBody]UpdateContractİnfoRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _contractInfoManager.UpdateContractInfo(request);
			return Ok(response);
		}
		[HttpDelete("RemoveContractInfo")]
		public async Task<IActionResult> RemoveContractInfo([FromQuery]RemoveContractİnfoRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response= await _contractInfoManager.DeleteContractInfo(request);
			return Ok(response);
		}
		[HttpGet("AllContractInfo")]
		public IActionResult AllContractInfo()
		{
			var response = _contractInfoManager.GetAllContractInfo();
			return Ok(response);
		}
		[HttpGet("AllContractInfoFilter")]
		public IActionResult AllContractInfoFilter([FromQuery]FilterContractİnfoRequest request)
		{
			var response = _contractInfoManager.GetAllContractInfoFilter(request);
			return Ok(response);
		}
		[HttpGet("ContractInfoFilter")]
		public IActionResult ContractInfoFilter([FromQuery]FilterContractİnfoRequest request)
		{
			var response = _contractInfoManager.GetContractInfoFilter(request);
			return Ok(response);
		}
		[HttpGet("ContractInfoById{contractInfoId}")]
		public async Task<IActionResult> ContractInfoById([FromRoute]int contractInfoId)
		{
			var response= await _contractInfoManager.GetContractInfoById(contractInfoId);
			return Ok(response);
		}
	}
}
