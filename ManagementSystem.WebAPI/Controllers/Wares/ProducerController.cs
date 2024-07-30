using MagamentSystem.Application.DataTransferObject.Wares.Producer;
using MagamentSystem.Application.Managers.Wares;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Wares
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "producerService")]
	[ApiController]
	public class ProducerController : ControllerBase
	{
		private readonly IProducerManager _producerManager;

		public ProducerController(IProducerManager producerManager)
		{
			_producerManager = producerManager;
		}

		[HttpPost("CreateProducer")]
		public async Task<IActionResult> CreateProducer([FromBody]CreateProducerRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response = await _producerManager.CreateProducer(request);
			return Ok(response);
		}
		[HttpPut("UpdateProducer")]
		public async Task<IActionResult> UpdateProducer([FromBody]UpdateProducerRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _producerManager.UpdateProducer(request);
			return Ok(response);
		}
		[HttpDelete("RemoveProducer")]
		public async Task<IActionResult> RemoveProducer([FromQuery]RemoveProducerRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response= await _producerManager.DeleteProducer(request);
			return Ok(response);
		}
		[HttpGet("ProducerList")]
		public IActionResult AllProducer()
		{
			var response= _producerManager.GetAllProducer();
			return Ok(response);
		}
		[HttpGet("AllProducerFilter")]
		public IActionResult AllProducerFilter([FromQuery]FilterProducerRequest request)
		{
			var response = _producerManager.GetAllProducerFilter(request);
			return Ok(response);
		}
		[HttpGet("ProducerFilter")]
		public IActionResult ProducerFilter([FromQuery]FilterProducerRequest request)
		{
			var response= _producerManager.GetProducerFilter(request);
			return Ok(response);
		}
		[HttpGet("ProducerById{producerId}")]
		public async Task<IActionResult> ProducerById([FromRoute]int producerId)
		{
			var response = await _producerManager.GetProducerById(producerId);
			return Ok(response);
		}
	}
}
