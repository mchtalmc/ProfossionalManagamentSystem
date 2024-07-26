using AutoMapper;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Experience;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Experiences;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class ExperienceManager : IExperienceManger
	{
		private readonly IExperienceReadRepository _experienceReadRepository;
		private readonly IExperiencesWriteRepository _experiencesWriteRepository;
		private readonly IMapper	_mapper;

		public ExperienceManager(IExperienceReadRepository experienceReadRepository, IExperiencesWriteRepository experiencesWriteRepository, IMapper mapper)
		{
			_experienceReadRepository = experienceReadRepository;
			_experiencesWriteRepository = experiencesWriteRepository;
			_mapper = mapper;
		}

		public Task<BaseResponse<bool>> CreateExperience(CreateExperienceRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> DeleteExperience(RemoveExperienceRequest request)
		{
			throw new NotImplementedException();
		}

		public BaseResponse<List<ExperienceResponse>> GetAllExperience()
		{
			throw new NotImplementedException();
		}

		public BaseResponse<List<ExperienceResponse>> GetAllExperienceFilter(FilterExperienceRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<ExperienceResponse>> GetExperienceById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<ExperienceResponse>> GetExperienceFilter(FilterExperienceRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> UpdateExperience(UpdateExperienceRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
