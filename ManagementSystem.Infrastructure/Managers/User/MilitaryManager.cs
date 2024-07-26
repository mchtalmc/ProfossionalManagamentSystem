using AutoMapper;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Military;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Healts;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class MilitaryManager : IMilitaryManager
	{
		private readonly IHealtReadRepository _healtReadManager;
		private readonly IHealtWriteRepository _healtWriteManager;
		private readonly IMapper _mapper;

		public MilitaryManager(IHealtReadRepository healtReadManager, IHealtWriteRepository healtWriteManager, IMapper mapper)
		{
			_healtReadManager = healtReadManager;
			_healtWriteManager = healtWriteManager;
			_mapper = mapper;
		}

		public Task<BaseResponse<bool>> CreateMilitaryStatus(CreateMilitaryRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> DeleteMilitaryStatus(RemoveMilitaryRequest request)
		{
			throw new NotImplementedException();
		}

		public BaseResponse<List<MilitaryResponse>> GetAllFilterMilitaryStatus(FilterMilitaryRequest request)
		{
			throw new NotImplementedException();
		}

		public BaseResponse<List<MilitaryResponse>> GetAllMilitaryStatus()
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<MilitaryResponse>> GetMilitaryStatusById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<MilitaryResponse>> GetMilitaryStatutsFilter(FilterMilitaryRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> UpdateMilitaryStatus(UpdateMilitaryRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
