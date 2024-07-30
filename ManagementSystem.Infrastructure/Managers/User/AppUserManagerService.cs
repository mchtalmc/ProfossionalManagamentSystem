using AutoMapper;
using Azure.Core;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.AppUser;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Users;
using ManagamentSystem.Core.Entities;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class AppUserManagerService : IAppUserManager
	{
		private readonly IAppUserReadRepository _appUserReadRepository;
		private readonly IAppUserWriteRepository _appUserWriteRepository;
		

		public AppUserManagerService(IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository)
		{
			_appUserReadRepository = appUserReadRepository;
			_appUserWriteRepository = appUserWriteRepository;
			
		}

		public AppUser CheckRegister(string email, string password)
		{
			var chekData = _appUserReadRepository.GetAll().Where(x=> x.RemovedDate==null);

			if (!string.IsNullOrEmpty(email))
			{
				chekData = chekData.Where(x => x.Email.Contains(email));
				if (!string.IsNullOrEmpty(password))
				{
					chekData=chekData.Where(x=> x.Password.Contains(password));	
				}
				return chekData.FirstOrDefault();
			}
			throw new Exception("NOT FOUND");
		}

		public async Task<BaseResponse<bool>> CreateAppUser(CreateAppUserRequest request)
		{
			AppUser mapAppUser = new AppUser
			{
				Name=request.Name,
				Email=request.Email,
				PhoneNumber=request.PhoneNumber,
				Address=request.Address,
				Password=request.Password,
				IsBlocked=request.IsBlocked,
				Title=request.Title,
				Gender=request.Gender,
				AddedBy=request.AddedBy,
				IsStatus=request.IsStatus,
				CreatedDate=DateTime.UtcNow
			};
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
			var users = _appUserReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			List<AppUserResponse> mapUser = new List<AppUserResponse>();
			foreach (var user in users)
			{
				AppUserResponse appUser = new AppUserResponse
				{
					Id=user.Id,
					Name=user.Name,
					Email=user.Email,
					PhoneNumber=user.PhoneNumber,
					Address=user.Address,
					Password=user.Password,
					IsBlocked=user.IsBlocked,
					Title=user.Title,
					Gender=user.Gender,
					AddedBy=user.AddedBy,
					ModifiedBy=user.ModifiedBy,
					RemovedBy=user.RemovedBy,
					IsStatus=user.IsStatus,
					ModifiedDate=user.ModifiedDate,
					RemovedDate=user.ModifiedDate,
					CreatedDate=user.CreatedDate,
				};
				mapUser.Add(appUser);
			}
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
			var response = query.Where(x=> x.RemovedDate == null).Select(x => new AppUserResponse
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
		
		

		public async Task<BaseResponse<AppUserResponse>> GetAppUserById(int id)
		{
			var checkData = await _appUserReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<AppUserResponse>(false, "User NOT FOUND");
			}
			AppUserResponse mapData = new AppUserResponse
			{
				Id=checkData.Id,
				Name = checkData.Name,
				Email = checkData.Email,
				PhoneNumber = checkData.PhoneNumber,
				Address = checkData.Address,
				Password = checkData.Password,
				IsBlocked = checkData.IsBlocked,
				Title = checkData.Title,
				Gender = checkData.Gender,
				AddedBy = checkData.AddedBy,
				IsStatus = checkData.IsStatus,
				CreatedDate =checkData.CreatedDate,
				ModifiedDate = checkData.ModifiedDate,
				ModifiedBy = checkData.ModifiedBy,
				RemovedBy = checkData.RemovedBy,
				RemovedDate = checkData.RemovedDate,
				
			};
			return new BaseResponse<AppUserResponse>(mapData, true, "USER :");

		}

		public BaseResponse<AppUserResponse> GetAppUserFilter(FilterAppUserRequest request)
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
			var response = query.Where(x => x.RemovedDate == null).Select(x => new AppUserResponse
			{
				Name = x.Name,
				Email = x.Email,
				PhoneNumber = x.PhoneNumber,
				Address = x.Address,
				Password = x.Password,
				IsBlocked = x.IsBlocked,
				Title = x.Title,
				Gender = x.Gender,
				AddedBy = x.AddedBy,
				ModifiedBy = x.ModifiedBy,
				RemovedBy = x.RemovedBy,
				ModifiedDate = x.ModifiedDate,
				RemovedDate = x.RemovedDate,
				CreatedDate = x.CreatedDate
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<AppUserResponse>(false, "USER NOT FOUND");
			}
			return new BaseResponse<AppUserResponse>(response, true, "USER :");
		}

		public async Task<BaseResponse<bool>> UpdateAppUser(UpdateAppUserRequest request)
		{
			var checkData = await _appUserReadRepository.GetSingleById(request.Id);
			if(checkData != null)
			{
				return new BaseResponse<bool>(false, "USER NOT FOUND");
			}
			checkData.Name=request.Name;
			checkData.Email=request.Email;
			checkData.PhoneNumber=request.PhoneNumber;
			checkData.Address=request.Address;
			checkData.Password=request.Password;
			checkData.IsStatus=request.IsStatus;
			checkData.IsBlocked=request.IsBlocked;
			checkData.Title=request.Title;
			checkData.Gender=request.Gender;
			checkData.ModifiedBy=request.ModifiedBy;
			checkData.ModifiedDate = DateTime.UtcNow;
			var update=  _appUserWriteRepository.Update(checkData);
			var save = await _appUserWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "UPDATE USER OPERATION FAILED");
			}
			return new BaseResponse<bool>(true, "UPDATE USER OPERATION SUCCESS");
		}
	}
}
