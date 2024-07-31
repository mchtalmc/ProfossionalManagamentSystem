using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.UserPermissionModel;
using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using MagamentSystem.Application.Services.Authorization;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Services.Authorization
{
	public class UserPermissionService : IUserPermissionService
	{
		private readonly IUserPermissionReadRepository _userPermissionReadRepository;
		private readonly IUserPermissionWriteRepository _userPermissionWriteRepository;

		public UserPermissionService(IUserPermissionReadRepository userPermissionReadRepository, IUserPermissionWriteRepository userPermissionWriteRepository)
		{
			_userPermissionReadRepository = userPermissionReadRepository;
			_userPermissionWriteRepository = userPermissionWriteRepository;
		}

		public async Task<BaseResponse<object>> Add(CreateUserPermission userClaim)
		{
			UserPermission map = new UserPermission
			{
				AppUsersId= userClaim.AppUsersId,
				CustomPermissionsId=userClaim.CustomPermissionsId,
			};
			var add = await _userPermissionWriteRepository.AddAsync(map);
			var save = await _userPermissionWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<object>(false, "User Permission Creating Operation FAILED");
			}
			return new BaseResponse<object>(true, "User Permission Creating Operation SUCCESS");

		}

		public async Task<BaseResponse<object>> AddRange(List<CreateUserPermission> userClaims)
		{
			List<UserPermission> map = new List<UserPermission>();
			foreach (var userClaim in userClaims)
			{
				UserPermission mapTo = new UserPermission
				{
					AppUsersId=userClaim.AppUsersId,
					CustomPermissionsId= userClaim.CustomPermissionsId,
				};
				map.Add(mapTo);
			}
			var addRange = await _userPermissionWriteRepository.AddRangeAsync(map);
			var save = await _userPermissionWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<object>(false, "Add Range Operation FAILED");
			}
			return new BaseResponse<object>(true, "Add Range Operation SUCCESS");
		}

		public async Task<BaseResponse<ResultUserPermission>> GetUserClaimById(int id)
		{
			var checkData = await _userPermissionReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ResultUserPermission>(false, "User Permission NOT FOUND");
			}
			ResultUserPermission userPermission = new ResultUserPermission
			{
				Id=checkData.Id,
				CustomPermissionsId=checkData.CustomPermissionsId,
				AppUsersId=checkData.AppUsersId
			};
			return new BaseResponse<ResultUserPermission>(userPermission, true, "User Permission :");
		}

		public BaseResponse<List<ResultUserPermission>> GetUserClaimList()
		{
			var datas = _userPermissionReadRepository.GetAll().ToList();
			if(datas is null)
			{
				return new BaseResponse<List<ResultUserPermission>>(false, "User Permission List is EMPTY");
			}
			List<ResultUserPermission> list= new List<ResultUserPermission>();
			foreach(var data in datas)
			{
				ResultUserPermission mapTo = new ResultUserPermission
				{
					Id=data.Id,
					CustomPermissionsId=data.CustomPermissionsId,
					AppUsersId=data.AppUsersId
				};
				list.Add(mapTo);
			}
			return new BaseResponse<List<ResultUserPermission>>(list, true, "User Permission LIST");
		}

		public List<string> GetUserPermissionWithUserId(int userId)
		{
			var datas = _userPermissionReadRepository.GetAll().Where(x=>x.AppUsersId==userId).ToList();
			var response= datas.Select(x=>x.CustomPermission.Value).ToList();
			return response;
		
		}

		

		public async Task<BaseResponse<object>> Update(UpdateUserPermission userClaim)
		{
			var checkData = await _userPermissionReadRepository.GetSingleById(userClaim.Id);
			if(checkData is null)
			{
				return new BaseResponse<object>(false, "User Permission NOT FOUND");
			}
			checkData.AppUsersId = userClaim.AppUsersId;
			checkData.CustomPermissionsId = userClaim.CustomPermissionsId;
			var update= _userPermissionWriteRepository.Update(checkData);
			var save = await _userPermissionWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<object>(false, "User Permission Update Operation FAILED");
			}
			return new BaseResponse<object>(true, "User Permission Update Operation SUCCESS");
		}
	}
}
