using AutoMapper;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Healt;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Healts;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class HealtManager : IHealtManager
	{
		private readonly IHealtReadRepository _healtReadRepository;
		private readonly IHealtWriteRepository _healtWriteRepository;
		private readonly IMapper _mapper;

		public HealtManager(IHealtReadRepository healtReadRepository, IHealtWriteRepository healtWriteRepository, IMapper mapper)
		{
			_healtReadRepository = healtReadRepository;
			_healtWriteRepository = healtWriteRepository;
			_mapper = mapper;
		}

		public Task<BaseResponse<bool>> CreateHealtStatus(CreateHealtyRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> DeleteHealtStatus(RemoveHealtyRequest request)
		{
			throw new NotImplementedException();
		}

		public BaseResponse<List<HealtResponse>> GetAllHealtStatus()
		{
			throw new NotImplementedException();
		}

		public BaseResponse<List<HealtResponse>> GetAllHealtStatusFilter(FilterHealtyRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<HealtResponse>> GetHealtStatusById(int id)
		{
			throw new NotImplementedException();
		}

		public BaseResponse<HealtResponse> GetHealtStatusFilter(FilterHealtyRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> UpdateHealtStatus(UpdateHealtyRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
