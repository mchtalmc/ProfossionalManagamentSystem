using MagamentSystem.Application.DataTransferObject.Wares.Product;
using MagamentSystem.Application.Managers.Wares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Wares
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "productService")]
	[ApiController]
	[Authorize]
	public class ProductController : ControllerBase
	{
		private readonly IProductManager _productManager;

		public ProductController(IProductManager productManager)
		{
			_productManager = productManager;
		}
		[HttpPost("CreateProduct")]
		public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.AddedBy = int.Parse(loginUserId);
			var response= await _productManager.CreateProduct(request);
			return Ok(response);
		}
		[HttpPut("UpdateProduct")]
		public async Task<IActionResult> UpdateProduct([FromBody]UpdateProductRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response = await _productManager.UpdateProduct(request);
			return Ok(response);
		}
		[HttpDelete("RemoveProduct")]
		public async Task<IActionResult> RemoveProduct([FromQuery]RemoveProductRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response = await _productManager.DeleteProduct(request);
			return Ok(response);
		}
		[HttpGet("AllProduct")]
		public IActionResult AllProduct()
		{
			var response = _productManager.GetAllProduct();
			return Ok(response);
		}
		[HttpGet("AllProductFilter")]
		public IActionResult AllProductFilter([FromQuery]FilterProductRequest request)
		{
			var response= _productManager.GetAllProductFilter(request);
			return Ok(response);
		}
		[HttpGet("ProductFilter")]
		public IActionResult ProductFilter([FromQuery]FilterProductRequest request)
		{
			var response = _productManager.GetProductFilter(request);
			return Ok(response);
		}
		[HttpGet("ProductById{productId}")]
		public async Task<IActionResult> ProductById([FromRoute]int productId)
		{
			var response= await _productManager.GetProductById(productId);
			return Ok(response);
		}
	}
}
