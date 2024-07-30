﻿using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.RolePermissionModel;
using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using MagamentSystem.Application.Services.Authorization;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Services.Authorization
{
	public class RolePermissionService : IRolePermissionService
	{
		private readonly IRolePermissionReadRepository _rolePermissionReadRepository;
		private readonly IRolePermissionWriteRepository _rolePermissionWriteRepository;

		public RolePermissionService(IRolePermissionReadRepository rolePermissionReadRepository, IRolePermissionWriteRepository rolePermissionWriteRepository)
		{
			_rolePermissionReadRepository = rolePermissionReadRepository;
			_rolePermissionWriteRepository = rolePermissionWriteRepository;
		}

		public async Task<BaseResponse<object>> Add(CreateRolePermission roleClaim)
		{
			RolePermission map = new RolePermission
			{
				RoleId=roleClaim.RoleId,
				PermissionId=roleClaim.PermissionId,
			};
			var add = await _rolePermissionWriteRepository.AddAsync(map);
			var save = await _rolePermissionWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<object>(false, "Creating Operation FAILED");
			}
			return new BaseResponse<object>(true, "Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<ResultRolePermission>> GetRoleClaimById(int id)
		{
			var checkData = await _rolePermissionReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ResultRolePermission>(false, "Role Permission NOT FOUND");
			}
			ResultRolePermission map = new ResultRolePermission
			{
				Id=checkData.Id,
				RoleId=checkData.RoleId,	
				PermissionId=checkData.PermissionId,
			};
			return new BaseResponse<ResultRolePermission>(map, true, "Role Permission :");
		}

		public BaseResponse<List<ResultRolePermission>> GetRoleClaimList()
		{
			var datas = _rolePermissionReadRepository.GetAll().ToList();
			if(datas is null)
			{
				return new BaseResponse<List<ResultRolePermission>>(false, "Role Permission List is EMPTY");
			}
			List<ResultRolePermission> list = new List<ResultRolePermission>();
			foreach (var data in datas)
			{
				ResultRolePermission mapTO = new ResultRolePermission
				{
					Id=data.Id,
					RoleId=data.RoleId,
					PermissionId=data.PermissionId,
				};
				list.Add(mapTO);
			}
			return new BaseResponse<List<ResultRolePermission>>(list, true, "Role Permission LIST");
		}

		public async Task<BaseResponse<object>> Update(UpdateRolePermission roleClaim)
		{
			var checkData = await _rolePermissionReadRepository.GetSingleById(roleClaim.Id);
			if(checkData is null)
			{
				return new BaseResponse<object>(false, "Role Permission NOT FOUND");
			}
			checkData.RoleId=roleClaim.RoleId;
			checkData.PermissionId=roleClaim.PermissionId;
			var update = _rolePermissionWriteRepository.Update(checkData);
			var save = await _rolePermissionWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<object>(false, "Updating Operation FAILED");
			}
			return new BaseResponse<object>(true, "Updating Operation SUCCESS");
		}
	}
}
