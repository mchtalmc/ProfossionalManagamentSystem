using MagamentSystem.Application.DataTransferObject.Wares.Category;
using MagamentSystem.Application.Managers.Wares;
using ManagamentSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Wares
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "categoryService")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryManager _categoryManager;

		public CategoryController(ICategoryManager categoryManager)
		{
			_categoryManager = categoryManager;
		}
		[HttpPost("Create Category")]
		public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			/request.AddedBy = int.Parse(loginUserId);
			var response= await _categoryManager.CreateCategory(request);
			return Ok(response);
		}
		[HttpPut("Update Category")]
		public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.ModifiedBy = int.Parse(loginUserId);
			var response= await _categoryManager.UpdateCategory(request);
			return Ok(response);
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(RemoveCategoryRequest request)
		{
			var loginUserId = User?.FindFirst("id")?.Value;
			request.RemovedBy = int.Parse(loginUserId);
			var response = await _categoryManager.DeleteCategory(request);
			return Ok(response);
		}
		[HttpGet("Category LIST")]
		public IActionResult CategoryList()
		{
			var response = _categoryManager.GetAllCategory();
			return Ok(response);
		}
		[HttpGet("Category LIST FILTER")]
		public IActionResult CategoryListFilter([FromQuery]FilterCategoryRequest request)
		{
			var reponse = _categoryManager.GetAllCategoryFilter(request);
			return Ok(reponse);
		}
		[HttpGet("Category FILTER")]
		public IActionResult CategoryFilter([FromQuery]FilterCategoryRequest request)
		{
			var response = _categoryManager.GetCategoryFilter(request);
			return Ok(response);
		}
		[HttpGet("CategoryById{categoryId}")]
		public async Task<IActionResult> CategoryById([FromRoute]int categoryId)
		{
			var response = await _categoryManager.GetCategoryById(categoryId);
			return Ok(response);
		}
	}
}
