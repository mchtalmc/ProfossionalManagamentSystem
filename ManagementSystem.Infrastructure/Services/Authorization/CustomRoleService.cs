using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.CustomRoleModel;
using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using MagamentSystem.Application.Services.Authorization;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Services.Authorization
{
	public class CustomRoleService : ICustomRoleService
	{
		private readonly ICustomRoleReadRepository _customRoleReadRepository;
		private readonly ICustomRoleWriteRepository _customRoleWriteRepository;

		public CustomRoleService(ICustomRoleReadRepository customRoleReadRepository, ICustomRoleWriteRepository customRoleWriteRepository)
		{
			_customRoleReadRepository = customRoleReadRepository;
			_customRoleWriteRepository = customRoleWriteRepository;
		}

		public async Task<BaseResponse<object>> Add(CreateRole role)
		{
			CustomRole map = new CustomRole
			{
				Name= role.Name,
				Description= role.Description,
				CreatedDate=DateTime.UtcNow
			};
			var add= await _customRoleWriteRepository.AddAsync(map);
			var save = await _customRoleWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<object>(false, "Creating Operation FAILED");
			}
			return new BaseResponse<object>(true, "Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<ResultRole>> GetRoleById(int id)
		{
			var checkData = await _customRoleReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ResultRole>(false, "Role NOT FOUND");
			}
			ResultRole resultRole = new ResultRole
			{
				Id=checkData.Id,
				Name=checkData.Name,
				Description=checkData.Description,
			};
			return new BaseResponse<ResultRole>(resultRole, true, "CUSTOM ROLE :");
		}

		public BaseResponse<List<ResultRole>> GetRoleList()
		{
			var datas = _customRoleReadRepository.GetAll().ToList();
			if(datas is null)
			{
				return new BaseResponse<List<ResultRole>>(false, "Custom Role List EMPT");
			}
			List<ResultRole> list = new List<ResultRole>();
			foreach(var data in datas)
			{
				ResultRole mapTo = new ResultRole
				{
					Id=data.Id,
					Name=data.Name,
					Description=data.Description,
				};
				list.Add(mapTo);
			}
			return new BaseResponse<List<ResultRole>>(list, true, "Custom Role LIST: ");
		}

		public async Task<BaseResponse<object>> Update(UpdateRole role)
		{
			var checkData= await _customRoleReadRepository.GetSingleById(role.Id);
			if(checkData is null)
			{
				return new BaseResponse<object>(false, "Custom Role NOT FOUND");
			}
			checkData.Name=role.Name;
			checkData.Description=role.Description;
			var update = _customRoleWriteRepository.Update(checkData);
			var save = await _customRoleWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<object>(false, "Updating Operation FAILED");
			}
			return new BaseResponse<object>(true, "Updating Operation SUCCESS");
		}
	}
}
