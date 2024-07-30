using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.DataTransferObject.Wares.Producer;

namespace MagamentSystem.Application.Managers.Wares
{
	public interface IProducerManager
	{
		Task<BaseResponse<bool>> CreateProducer(CreateProducerRequest request);
		Task<BaseResponse<bool>> UpdateProducer(UpdateProducerRequest request);
		Task<BaseResponse<bool>> DeleteProducer(RemoveProducerRequest request);
		BaseResponse<List<ProducerResponse>> GetAllProducer();
		BaseResponse<List<ProducerResponse>> GetAllProducerFilter(FilterProducerRequest request);
		BaseResponse<ProducerResponse> GetProducerFilter(FilterProducerRequest request);
		Task<BaseResponse<ProducerResponse>> GetProducerById(int id);
	}
}
