using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.DataTransferObject.Wares.Category;

namespace MagamentSystem.Application.Managers.Wares
{
	public interface ICategoryManager
	{
		Task<BaseResponse<bool>> CreateCategory(CreateCategoryRequest request);
		Task<BaseResponse<bool>> UpdateCategory(UpdateCategoryRequest request);
		Task<BaseResponse<bool>> DeleteCategory(RemoveCategoryRequest request);
		BaseResponse<List<CategoryResponse>> GetAllCategory();
		BaseResponse<List<CategoryResponse>> GetAllCategoryFilter(FilterCategoryRequest request);
		BaseResponse<CategoryResponse> GetCategoryFilter(FilterCategoryRequest request);
		Task<BaseResponse<CategoryResponse>> GetCategoryById(int id);
	}
}
