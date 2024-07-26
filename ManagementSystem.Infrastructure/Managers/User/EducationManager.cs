﻿using AutoMapper;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Education;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Educations;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class EducationManager : IEducationManager
	{
		private readonly IEducationReadRepository _educationReadRepository;
		private readonly IEducationWriteRepository _educationWriteRepository;
		private readonly IMapper _mapper;

		public EducationManager(IEducationReadRepository educationReadRepository, IEducationWriteRepository educationWriteRepository, IMapper mapper)
		{
			_educationReadRepository = educationReadRepository;
			_educationWriteRepository = educationWriteRepository;
			_mapper = mapper;
		}

		public async Task<BaseResponse<bool>> CreateEducation(CreateEducationRequest request)
		{
			var dto = _mapper.Map<EducationStatus>(request);
			var response= await _educationWriteRepository.AddAsync(dto);
			var save = await _educationWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Adding FAILED");
			}
			return new BaseResponse<bool>(true, "Adding Success");
		}

		public async Task<BaseResponse<bool>> DeleteEducation(RemoveEducationRequest request)
		{
			var checkData = await _educationReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Education Informatin Not Found");
			}
			checkData.RemovedBy= request.Id;
			checkData.RemovedDate = DateTime.UtcNow;
			var response = _educationWriteRepository.Update(checkData);
			var save = await _educationWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Removed Operation Failed ");
			}
			return new BaseResponse<bool>(true, "Removed Operation Success");
		}

		public BaseResponse<List<EducationResponse>> GetAllEducation()
		{
			var getData= _educationReadRepository.GetAll().ToList();
			if(getData is null)
			{
				return new BaseResponse<List<EducationResponse>>(false, "Education List's NOT FOUND");
			}

			var mapData = _mapper.Map<List<EducationResponse>>(getData);
			return new BaseResponse<List<EducationResponse>>(mapData, true, "Education List's :");

		}

		public BaseResponse<List<EducationResponse>> GetAllEducationFilter(FilterEducationRequest request)
		{
			var query = _educationReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Department))
			{
				query=query.Where(x=> x.Department.Contains(request.Department));
			}
			if (!string.IsNullOrEmpty(request.GraduatedSchool))
			{
				query=query.Where(x=> x.GraduatedSchool.Contains(request.GraduatedSchool));
			}
			if (!string.IsNullOrEmpty(request.YearOfGraduation.Year.ToString()))
			{
				int year = request.YearOfGraduation.Year;
				query = query.Where(x => x.YearOfGraduation.Year == year); // Guvenmiyorum ama is gorur gibi
			}
			var response = query.Select(x => new EducationResponse
			{
				Id=x.Id,
				GraduatedSchool=x.GraduatedSchool,
				AddedBy=x.AddedBy,
				CreatedDate=x.CreatedDate,
				Department=x.Department,	
				GraduationScore=x.GraduationScore,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate=x.ModifiedDate,
				RemovedBy=x.RemovedBy,
				RemovedDate=x.RemovedDate,
				UserId=x.AppUser.Id,
				YearOfGraduation = x.YearOfGraduation
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<EducationResponse>>(false, "Filter operation's result is EMPTY");
			}
			return new BaseResponse<List<EducationResponse>>(response, true, "Filter Operation's RESULT: ");

		}

		public async Task<BaseResponse<EducationResponse>> GetEducationById(int id)
		{
			var checkData = await _educationReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<EducationResponse>(false, "Education Information's NOT FOUND");
			}
			var mapData = _mapper.Map<EducationResponse>(checkData);
			return new BaseResponse<EducationResponse>(mapData, true, "Education Information's RESULT");
		}

		public BaseResponse<EducationResponse> GetEducationFilter(FilterEducationRequest request)
		{
			var query = _educationReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Department))
			{
				query = query.Where(x => x.Department.Contains(request.Department));
			}
			if (!string.IsNullOrEmpty(request.GraduatedSchool))
			{
				query = query.Where(x => x.GraduatedSchool.Contains(request.GraduatedSchool));
			}
			if (!string.IsNullOrEmpty(request.YearOfGraduation.Year.ToString()))
			{
				int year = request.YearOfGraduation.Year;
				query = query.Where(x => x.YearOfGraduation.Year == year); // Guvenmiyorum ama is gorur gibi
			}
			var response = query.Select(x =>  new EducationResponse
			{
				Id = x.Id,
				GraduatedSchool = x.GraduatedSchool,
				AddedBy = x.AddedBy,
				CreatedDate = x.CreatedDate,
				Department = x.Department,
				GraduationScore = x.GraduationScore,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				RemovedBy = x.RemovedBy,
				RemovedDate = x.RemovedDate,
				UserId = x.AppUser.Id,
				YearOfGraduation = x.YearOfGraduation
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<EducationResponse>(false, "Education Information's NOT FOUND");
			}
			return new BaseResponse<EducationResponse>(response, true, "Education Information's : ");

		}

		public async Task<BaseResponse<bool>> UpdateEducation(UpdateEducationRequest request)
		{
			var checkData = await _educationReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Education Information's NOT FOUND");
			}
			var mapData = _mapper.Map(request, checkData);
			var response= _educationWriteRepository.Update(mapData);
			var save = await _educationWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Update Education Information's Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Update Education Information's Operation SUCCESS");

		}
	}
}