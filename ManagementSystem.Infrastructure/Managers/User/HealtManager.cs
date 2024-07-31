using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Healt;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Healts;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class HealtManager : IHealtManager
	{
		private readonly IHealtReadRepository _healtReadRepository;
		private readonly IHealtWriteRepository _healtWriteRepository;


		public HealtManager(IHealtReadRepository healtReadRepository, IHealtWriteRepository healtWriteRepository)
		{
			_healtReadRepository = healtReadRepository;
			_healtWriteRepository = healtWriteRepository;

		}

		public async Task<BaseResponse<bool>> CreateHealtStatus(CreateHealtyRequest request)
		{
			HealthStatus mapData = new HealthStatus
			{
				HaveADisase = request.HaveADisase,
				WhatDiesase = request.WhatDiesase,
				DisabilityStatus = request.DisabilityStatus,
				WhatSidability = request.WhatSidability,
				CanUseVehicle = request.CanUseVehicle,
				AddedBy = request.AddedBy,
				AppUserId=request.AppUserId,
				IsStatus = request.IsStatus,
				CreatedDate = DateTime.UtcNow
			};
			var response = await _healtWriteRepository.AddAsync(mapData);
			var save = await _healtWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Healty Information Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Healty Information Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteHealtStatus(RemoveHealtyRequest request)
		{
			var checkData = await _healtReadRepository.GetSingleById(request.Id);
			if (checkData is null)
			{
				return new BaseResponse<bool>(false, "Healty Information NOT FOUND");
			}
			checkData.RemovedBy = request.RemovedBy;
			checkData.RemovedDate = DateTime.Now;
			var response = _healtWriteRepository.Remove(checkData);
			var save = await _healtWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "HEALTY INFORMATION REMOVE OPERATION FAILED");
			}
			return new BaseResponse<bool>(true, " HEALTY INFORMATION REMOVE OPERATION SUCCESS");
		}

		public BaseResponse<List<HealtResponse>> GetAllHealtStatus()
		{
			var data = _healtReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			if (data is null)
			{
				return new BaseResponse<List<HealtResponse>>(false, "HEALTY INFORMATION LIST IS EMPTY");
			}
			List<HealtResponse> mapData = new List<HealtResponse>();
			foreach (var item in data)
			{
				HealtResponse map = new HealtResponse
				{
					Id = item.Id,
					AppUserId= item.AppUserId,
					HaveADisase = item.HaveADisase,
					WhatDiesase = item.WhatDiesase,
					DisabilityStatus = item.DisabilityStatus,
					WhatSidability = item.WhatSidability,
					CanUseVehicle = item.CanUseVehicle,
					AddedBy = item.AddedBy,
					ModifiedBy = item.ModifiedBy,
					RemovedBy = item.RemovedBy,
					IsStatus = item.IsStatus,
					CreatedDate = item.CreatedDate,
					ModifiedDate = item.ModifiedDate,
					RemovedDate = item.RemovedDate,
				};
				mapData.Add(map);
			}
			return new BaseResponse<List<HealtResponse>>(mapData, true, "HEALTY INFORMATION LIST");
		}

		public BaseResponse<List<HealtResponse>> GetAllHealtStatusFilter(FilterHealtyRequest request)
		{
			var query = _healtReadRepository.GetAll().Where(x => x.RemovedDate == null);

			if (request.HaveADisase.HasValue)
			{
				query = query.Where(x => x.HaveADisase == request.HaveADisase.Value);
			}

			if (request.DisabilityStatus.HasValue)
			{
				query = query.Where(x => x.DisabilityStatus == request.DisabilityStatus.Value);
			}

			if (request.CanUseVehicle.HasValue)
			{
				query = query.Where(x => x.CanUseVehicle == request.CanUseVehicle.Value);
			}

			if (request.AppUserId.HasValue)
			{
				query = query.Where(x => x.AppUser.Equals(request.AppUserId));
			}

			var result = query.Select(x => new HealtResponse
			{
				ModifiedBy = x.ModifiedBy,
				RemovedBy = x.RemovedBy,
				DisabilityStatus = x.DisabilityStatus,
				WhatDiesase = x.WhatDiesase,
				WhatSidability = x.WhatSidability,
				AddedBy = x.AddedBy,
				CanUseVehicle = x.CanUseVehicle,
				CreatedDate = x.CreatedDate,
				HaveADisase = x.HaveADisase,
				ModifiedDate = x.ModifiedDate,
				Id = x.Id,
				AppUserId=x.AppUserId,

			}).ToList();
			if (result is null)
			{
				return new BaseResponse<List<HealtResponse>>(false, "HEALTY LIST IS EMPTY");
			}
			return new BaseResponse<List<HealtResponse>>(result, true, "HEALTY LIST:");
		}

		public async Task<BaseResponse<HealtResponse>> GetHealtStatusById(int id)
		{
			var checkData = await _healtReadRepository.GetSingleById(id);
			if (checkData is null)
			{
				return new BaseResponse<HealtResponse>(false, "HEALTY STATUS NOT FOUND");
			}
			HealtResponse mapData = new HealtResponse
			{
				Id = checkData.Id,
				AppUserId= checkData.AppUserId,
				HaveADisase = checkData.HaveADisase,
				WhatDiesase = checkData.WhatDiesase,
				DisabilityStatus = checkData.DisabilityStatus,
				WhatSidability = checkData.WhatSidability,
				CanUseVehicle = checkData.CanUseVehicle,
				AddedBy = checkData.AddedBy,
				IsStatus = checkData.IsStatus,
				CreatedDate = checkData.CreatedDate,
				RemovedDate = checkData.RemovedDate,
				ModifiedDate = checkData.ModifiedDate,
				RemovedBy = checkData.RemovedBy,
				ModifiedBy = checkData.ModifiedBy,

			};
		
			return new BaseResponse<HealtResponse>(mapData, true, "HEALT STATUS :");
		}

		public BaseResponse<HealtResponse> GetHealtStatusFilter(FilterHealtyRequest request)
		{
			var query = _healtReadRepository.GetAll().Where(x => x.RemovedDate == null);

			if (request.HaveADisase.HasValue)
			{
				query = query.Where(x => x.HaveADisase == request.HaveADisase.Value);
			}

			if (request.DisabilityStatus.HasValue)
			{
				query = query.Where(x => x.DisabilityStatus == request.DisabilityStatus.Value);
			}

			if (request.CanUseVehicle.HasValue)
			{
				query = query.Where(x => x.CanUseVehicle == request.CanUseVehicle.Value);
			}

			if (request.AppUserId.HasValue)
			{
				query = query.Where(x => x.AppUserId == request.AppUserId.Value);
			}

			var result = query.Select(x => new HealtResponse
			{
				ModifiedBy = x.ModifiedBy,
				RemovedBy = x.RemovedBy,
				DisabilityStatus = x.DisabilityStatus,
				WhatDiesase = x.WhatDiesase,
				WhatSidability = x.WhatSidability,
				AddedBy = x.AddedBy,
				CanUseVehicle = x.CanUseVehicle,
				CreatedDate = x.CreatedDate,
				HaveADisase = x.HaveADisase,
				ModifiedDate = x.ModifiedDate,
				Id = x.Id,
				AppUserId= x.AppUserId,

			}).FirstOrDefault();
			if(result is null)
			{
				return new BaseResponse<HealtResponse>(false, "HEALT STATUS NOT FOUND");
			}
			return new BaseResponse<HealtResponse>(result, true, "HEALT STATUS");
		}

		public async Task<BaseResponse<bool>> UpdateHealtStatus(UpdateHealtyRequest request)
		{
			var checkData = await _healtReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "HEALTY STATUS NOT FOUND");
			}
			checkData.HaveADisase = request.HaveADisase;
			checkData.WhatDiesase=request.WhatDiesase;
			checkData.DisabilityStatus=request.DisabilityStatus;
			checkData.WhatDiesase= request.WhatDiesase;
			checkData.WhatSidability=request.WhatSidability;
			checkData.CanUseVehicle=request.CanUseVehicle;
			checkData.ModifiedBy=request.ModifiedBy;
			checkData.IsStatus=request.IsStatus;
			checkData.ModifiedDate = DateTime.UtcNow;
			var response= _healtWriteRepository.Update(checkData);
			var save = await _healtWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "HEALTY STATUS UPDATE OPERATION FAILED");
			}
			return new BaseResponse<bool>(true, "HEALT STATUS UPDATE OPERATION SUCCESS");
		}
	}
}
