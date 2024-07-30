using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.CustomPermissionModel;
using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using MagamentSystem.Application.Services.Authorization;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Services.Authorization
{
	public class CustomPermissionService : ICustomPermissionService
	{
		private readonly ICustomPermissionReadRepository _customPermissionReadRepository;
		private readonly ICustomPermissionWriteRepository _customPermissionWriteRepository;

		public CustomPermissionService(ICustomPermissionReadRepository customPermissionReadRepository, ICustomPermissionWriteRepository customPermissionWriteRepository)
		{
			_customPermissionReadRepository = customPermissionReadRepository;
			_customPermissionWriteRepository = customPermissionWriteRepository;
		}

		public async Task<BaseResponse<object>> AddPermisson(CreatePermission createPermisson)
		{
			CustomPermission map = new CustomPermission
			{
				Type=createPermisson.Type,
				Value=createPermisson.Value,
				CreatedDate=DateTime.UtcNow

			};
			var response = await _customPermissionWriteRepository.AddAsync(map);
			var save = await _customPermissionWriteRepository.Save();
			if(save <0)
			{
				return new BaseResponse<object>(false, "Creating Operation FAILED");
			}
			return new BaseResponse<object>(true, "Creating Operation SUCCESS");

		}

		public async Task<BaseResponse<ResultPermission>> GetResultPermissionById(int id)
		{
			var checkData = await _customPermissionReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ResultPermission>(false, "Permission NOT FOUND");
			}
			ResultPermission map = new ResultPermission
			{
				Id=checkData.Id,
				Type=checkData.Type,
				Value=checkData.Value,
			};
			return new BaseResponse<ResultPermission>(map, true, "Permission :");
		}

		public BaseResponse<List<ResultPermission>> GetResultPermissionList()
		{
			var datas = _customPermissionReadRepository.GetAll().ToList();
			if(datas is null)
			{
				return new BaseResponse<List<ResultPermission>>(false, "Permission List is EMPTY");
			}
			List<ResultPermission> list = new List<ResultPermission>();
			foreach(var data in datas)
			{
				ResultPermission mapTO = new ResultPermission
				{
					Id=data.Id,
					Type=data.Type,
					Value=data.Value,
				};
				list.Add(mapTO);
			}
			return new BaseResponse<List<ResultPermission>>(list, true, "Permission LIST");
			
		}

		public async Task<BaseResponse<object>> UpdatePermisson(UpdatePermission updatePermission)
		{
			var checkData = await _customPermissionReadRepository.GetSingleById(updatePermission.Id);
			if(checkData is null)
			{
				return new BaseResponse<object>(false, "Permission NOT FOUND");
			}
			checkData.Type = updatePermission.Type;
			checkData.Value=updatePermission.Value;
			var update= _customPermissionWriteRepository.Update(checkData);
			var save = await _customPermissionWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<object>(false, "Updating Operation FAILED");
			}
			return new BaseResponse<object>(true, "Updating Operation SUCCESS");
		}
	}
}
