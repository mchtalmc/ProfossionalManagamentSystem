using AutoMapper;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.AppUser;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Users;
using ManagamentSystem.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class AppUserManagerService : IAppUserManager
	{
		private readonly IAppUserReadRepository _appUserReadRepository;
		private readonly IAppUserWriteRepository _appUserWriteRepository;
		private readonly IMapper _mapper;

		public AppUserManagerService(IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository, IMapper mapper)
		{
			_appUserReadRepository = appUserReadRepository;
			_appUserWriteRepository = appUserWriteRepository;
			_mapper = mapper;
		}

		public async Task<BaseResponse<bool>> CreateAppUser(CreateAppUserRequest request)
		{
			var mapAppUser = _mapper.Map<AppUser>(request);
			var response = await _appUserWriteRepository.AddAsync(mapAppUser);
			var save = await _appUserWriteRepository.Save();
			if(save is <0)
			{
				return new BaseResponse<bool>(false, "Addition Failed");
			}
			return new BaseResponse<bool>(true, "Addition Success");
			
		}

		public async Task<BaseResponse<bool>> DeleteAppUser(RemoveAppUserRequest request)
		{
			var checkUser = await _appUserReadRepository.GetSingleById(request.Id);
			if(checkUser is null)
			{
				return new BaseResponse<bool>(false, "User n't Found");
			}
			checkUser.RemovedBy = request.RemovedBy;
			checkUser.RemovedDate = DateTime.UtcNow;
			var response =  _appUserWriteRepository.Remove(checkUser);
			var save= await _appUserWriteRepository.Save();
			if(save is <0)
			{
				return new BaseResponse<bool>(false, "Delete opperation failed");
			}
			return new BaseResponse<bool>(true, "Delete operration success");
		}

		public BaseResponse<List<AppUserResponse>> GetAllAppUser()
		{
			var users = _appUserReadRepository.GetAll().ToList();
			var mapUser= _mapper.Map<List<AppUserResponse>>(users);
			return new BaseResponse<List<AppUserResponse>>(mapUser, true, "All Users");
		}

		public BaseResponse<List<AppUserResponse>> GetAllAppUserFilter(FilterAppUserRequest request)
		{
			var query = _appUserReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Name))
			{
				query = query.Where(x => x.Name.Contains(request.Name));
			}
			if (!string.IsNullOrEmpty(request.Address))
			{
				query = query.Where(x => x.Address.Contains(request.Address));
			}
			if (!string.IsNullOrEmpty(request.Title))
			{
				query = query.Where(x => x.Title.Contains(request.Title));
			}
			if (!string.IsNullOrEmpty(request.IsBlocked.ToString()))
			{
				query = query.Where(x => x.IsBlocked.ToString().Contains(request.IsBlocked.ToString()));
			}
			if (!string.IsNullOrEmpty(request.Gender.ToString()))
			{
				query = query.Where(x => x.Gender.ToString().Contains(request.Gender.ToString()));
			}
			var response = query.Select(x => new AppUserResponse
			{
				Name=x.Name,
				Email=x.Email,
				PhoneNumber=x.PhoneNumber,
				Address=x.Address,
				Password=x.Password,
				IsBlocked=x.IsBlocked,
				Title=x.Title,
				Gender=x.Gender,
				AddedBy=x.AddedBy,
				ModifiedBy=x.ModifiedBy,
				RemovedBy=x.RemovedBy,
				ModifiedDate=x.ModifiedDate,
				RemovedDate=x.RemovedDate,
				CreatedDate=x.CreatedDate
			}).ToList();

			if(response is null)
			{
				return new BaseResponse<List<AppUserResponse>>(false, "Users not found");
			}
			return new BaseResponse<List<AppUserResponse>>(response, true, "Filtered Users");
		}
		
		

		public Task<BaseResponse<AppUserResponse>> GetAppUserById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<AppUserResponse>> GetAppUserFilter(FilterAppUserRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> UpdateAppUser(UpdateAppUserRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
