using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Experience;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Experiences;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class ExperienceManager : IExperienceManger
	{
		private readonly IExperienceReadRepository _experienceReadRepository;
		private readonly IExperiencesWriteRepository _experiencesWriteRepository;
		

		public ExperienceManager(IExperienceReadRepository experienceReadRepository, IExperiencesWriteRepository experiencesWriteRepository)
		{
			_experienceReadRepository = experienceReadRepository;
			_experiencesWriteRepository = experiencesWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateExperience(CreateExperienceRequest request)
		{
			Experience mapData = new Experience
			{
				HowFieldWork=request.HowFieldWork,
				HowManyYear=request.HowManyYear,
				City=request.City,
				Country=request.Country,
				WhichTitle=request.WhichTitle,
				AddedBy=request.AddedBy,
				IsStatus=request.IsStatus,
				CreatedDate=DateTime.UtcNow

			};
		
			var response= await _experiencesWriteRepository.AddAsync(mapData);
			var save = await _experiencesWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Experiecne Create OPERATION FAILED");
			}
			return new BaseResponse<bool>(true, "Experience Create Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteExperience(RemoveExperienceRequest request)
		{
			var checkData = await _experienceReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Experience IS NULL");
			}
			checkData.RemovedBy=request.Id;
			checkData.RemovedDate = request.RemovedDate;
			var response = _experiencesWriteRepository.Remove(checkData);
			var save = await _experiencesWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "EXPERIENCE REMOVE OPERRATION FAILED");
			}
			return new BaseResponse<bool>(true, "EXPERIENCE REMVOE OPERRATION SUCCESS");
		}

		public BaseResponse<List<ExperienceResponse>> GetAllExperience()
		{
			var query = _experienceReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			if(query is null)
			{
				return new BaseResponse<List<ExperienceResponse>>(false, "Experience LIST is EMPTY");
			}
			List<ExperienceResponse> mapData = new List<ExperienceResponse>();
			foreach (var experience in query)
			{
				ExperienceResponse response = new ExperienceResponse
				{
					Id=experience.Id,
					HowManyYear=experience.HowManyYear,
					HowFieldWork=experience.HowFieldWork,
					City=experience.City,
					Country=experience.Country,
					WhichTitle=experience.WhichTitle,
					AddedBy=experience.AddedBy,
					ModifiedBy=experience.ModifiedBy,
					RemovedBy=experience.RemovedBy,
					IsStatus=experience.IsStatus,
					CreatedDate=experience.CreatedDate,
					RemovedDate=experience.RemovedDate,
					ModifiedDate=experience.ModifiedDate,
				};
				mapData.Add(response);
			}
			return new BaseResponse<List<ExperienceResponse>>(mapData, true, "EXPERIENCE LIST: ");
		}

		public  BaseResponse<List<ExperienceResponse>> GetAllExperienceFilter(FilterExperienceRequest request)
		{
			var query =  _experienceReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.City))
			{
				query=query.Where(x=>x.City.Contains(request.City));	
			}
			if(!string.IsNullOrEmpty(request.Country))
			{
				query=query.Where(x=>x.Country.Contains(request.Country));
			}
			if (!string.IsNullOrEmpty(request.WhichTitle))
			{
				query = query.Where(x => x.WhichTitle.Contains(request.WhichTitle));
			}

			var response = query.Where(x => x.RemovedDate == null).Select(x => new ExperienceResponse
			{
				RemovedDate = x.RemovedDate,
				AddedBy = x.AddedBy,
				City = x.City,
				Country = x.Country,
				CreatedDate = x.CreatedDate,
				HowFieldWork = x.HowFieldWork,
				HowManyYear = x.HowManyYear,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				RemovedBy = x.RemovedBy,
				WhichTitle = x.WhichTitle,
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<ExperienceResponse>>(false, "EXPERIENCE NOT FOUND");
			}
			return new BaseResponse<List<ExperienceResponse>>(response, true, "EXPERIENCE LIST:");
		}

		public async Task<BaseResponse<ExperienceResponse>> GetExperienceById(int id)
		{
			var checkData = await _experienceReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ExperienceResponse>(false, "EXPERIENCE NOT FOUND");
			}
			ExperienceResponse map = new ExperienceResponse
			{
				Id=checkData.Id,
				HowFieldWork = checkData.HowFieldWork,
				HowManyYear = checkData.HowManyYear,
				City = checkData.City,
				Country = checkData.Country,
				WhichTitle = checkData.WhichTitle,
				AddedBy = checkData.AddedBy,
				IsStatus = checkData.IsStatus,
				CreatedDate = checkData.CreatedDate,
				ModifiedDate = checkData.ModifiedDate,
				RemovedDate = checkData.RemovedDate,
				ModifiedBy = checkData.ModifiedBy,
				RemovedBy = checkData.RemovedBy
			};
			return new BaseResponse<ExperienceResponse>(map, true, "EXPERIENCE :");
		}

		public BaseResponse<ExperienceResponse> GetExperienceFilter(FilterExperienceRequest request)
		{
			var query = _experienceReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.City))
			{
				query = query.Where(x => x.City.Contains(request.City));
			}
			if (!string.IsNullOrEmpty(request.Country))
			{
				query = query.Where(x => x.Country.Contains(request.Country));
			}
			if (!string.IsNullOrEmpty(request.WhichTitle))
			{
				query = query.Where(x => x.WhichTitle.Contains(request.WhichTitle));
			}

			var response = query.Where(x => x.RemovedDate == null).Select(x => new ExperienceResponse
			{
				RemovedDate = x.RemovedDate,
				AddedBy = x.AddedBy,
				City = x.City,
				Country = x.Country,
				CreatedDate = x.CreatedDate,
				HowFieldWork = x.HowFieldWork,
				HowManyYear = x.HowManyYear,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				RemovedBy = x.RemovedBy,
				WhichTitle = x.WhichTitle,
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<ExperienceResponse>(false, "EXPERIENCE LIST IS EMPTY");
			}
			return new BaseResponse<ExperienceResponse>(response, true, "EXPERIENCE LIST");
		}

		public async Task<BaseResponse<bool>> UpdateExperience(UpdateExperienceRequest request)
		{
			var checkData = await _experienceReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "EXPERIENCE NOT FOUND");
			}
			checkData.HowManyYear = request.HowManyYear;
			checkData.HowFieldWork=request.HowFieldWork;
			checkData.City=request.City;
			checkData.Country=request.Country;	
			checkData.WhichTitle=request.WhichTitle;	
			checkData.ModifiedBy=request.ModifiedBy;
			checkData.IsStatus=request.IsStatus;
			checkData.ModifiedDate = DateTime.UtcNow;
			var response = _experiencesWriteRepository.Update(checkData);
			var save = await _experiencesWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "UPDATE EXPERIENCE OPERATION FAILED");
			}
			return new BaseResponse<bool>(true, "UPDATE EXPERIENCE OPERATION SUCCESS");
		}
	}
}
