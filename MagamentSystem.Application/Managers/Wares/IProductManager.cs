using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.DataTransferObject.Wares.Producer;
using MagamentSystem.Application.DataTransferObject.Wares.Product;

namespace MagamentSystem.Application.Managers.Wares
{
	public interface IProductManager
	{
		Task<BaseResponse<bool>> CreateProduct(CreateProductRequest request);
		Task<BaseResponse<bool>> UpdateProduct(UpdateProductRequest request);
		Task<BaseResponse<bool>> DeleteProduct(RemoveProductRequest request);
		BaseResponse<List<ProductResponse>> GetAllProduct();
		BaseResponse<List<ProductResponse>> GetAllProductFilter(FilterProductRequest request);
		BaseResponse<ProductResponse> GetProductFilter(FilterProductRequest request);
		Task<BaseResponse<ProductResponse>> GetProductById(int id);
	}
}
