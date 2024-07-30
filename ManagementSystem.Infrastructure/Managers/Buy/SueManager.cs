using AutoMapper;
using Azure.Core;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Sue;
using MagamentSystem.Application.Managers.Buy;
using MagamentSystem.Application.Repository.BuyRepository.Sues;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Managers.Buy
{
	public class SueManager : ISueManager
	{
		private readonly ISueReadRepository _sueReadRepository;
		private readonly ISueWriteRepository _sueWriteRepository;
		

		public SueManager(ISueReadRepository sueReadRepository, ISueWriteRepository sueWriteRepository)
		{
			_sueReadRepository = sueReadRepository;
			_sueWriteRepository = sueWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateSue(CreateSueRequest request)
		{
			Sue map = new Sue
			{
				SueNumber = request.SueNumber,
				SueTypeNumber = request.SueTypeNumber,
				SurStatus = request.SurStatus,
				AppUserId = request.AppUserId,
				SueDetailsId = request.SueDetailsId,
				AddedBy = request.AddedBy,
				IsStatus = request.IsStatus,
				CreatedDate = DateTime.UtcNow,
			};
			var response= await _sueWriteRepository.AddAsync(map);
			var save = await _sueWriteRepository.Save();
			if(save <0)
			{
				return new BaseResponse<bool>(false, "Sue Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Sue Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteSue(RemoveSueRequest request)
		{
			var checkData = await _sueReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Sue NOT FOUND");
			}
			checkData.RemovedBy=request.Id;
			checkData.RemovedDate = DateTime.UtcNow;
			var response= _sueWriteRepository.Update(checkData);
			var save= await _sueWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Sue Removing Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Sue Removing Operation SUCCESS");
		}

		public BaseResponse<List<SueResponse>> GetAllSue()
		{
			var datas = _sueReadRepository.GetAll().Where(x => x.RemovedDate == null);
			if(datas is null)
			{
				return new BaseResponse<List<SueResponse>>(false, "Sue LIST is EMPTY");
			}
			List<SueResponse> map = new List<SueResponse>();
			foreach (var data in datas)
			{
				SueResponse mapTo = new SueResponse
				{
					Id=data.Id,
					SueNumber=data.SueNumber,
					SueTypeNumber=data.SueTypeNumber,
					SurStatus=data.SurStatus,
					AppUserId=data.AppUserId,
					SueDetailsId=data.SueDetailsId,
					AddedBy=data.AddedBy,
					ModifiedBy=data.ModifiedBy,
					RemovedBy=data.RemovedBy,
					IsStatus=data.IsStatus,
					CreatedDate=data.CreatedDate,
					RemovedDate=data.RemovedDate,
					ModifiedDate=data.ModifiedDate,
				};
				map.Add(mapTo);
			}
			return new BaseResponse<List<SueResponse>>(map, true, "SUE LIST");
		}

		public BaseResponse<List<SueResponse>> GetAllSueFilter(FilterSueRequest request)
		{
			var query = _sueReadRepository.GetAll();
			if (request.SurStatus.HasValue)
			{
				query=query.Where(x=> x.SurStatus==request.SurStatus);
			}
			if(request.AppUserId.HasValue)
			{
				query = query.Where(x => x.AppUserId == request.AppUserId);
			}
			if (request.SueDetailsId.HasValue)
			{
				query=query.Where(x=> x.SueDetailsId==request.SueDetailsId);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new SueResponse
			{
				RemovedDate = x.RemovedDate,
				SueDetailsId = x.SueDetailsId,
				AddedBy=x.AddedBy,
				AppUserId=x.AppUserId,
				CreatedDate=x.CreatedDate,
				Id=x.Id,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate=x.ModifiedDate,
				RemovedBy=x.RemovedBy,
				SueNumber=x.SueNumber,
				SueTypeNumber=x.SueTypeNumber,
				SurStatus = x.SurStatus
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<SueResponse>>(false, "Sue LIST is EMPTY");
			}
			return new BaseResponse<List<SueResponse>>(response, true, " SUE LIST");
		}

		public async Task<BaseResponse<SueResponse>> GetSueById(int id)
		{
			var checkData = await _sueReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<SueResponse>(false, "Sue NOT FOUND");
			}
			SueResponse map = new SueResponse
			{
				Id=checkData.Id,
				SueNumber = checkData.SueNumber,
				SueTypeNumber = checkData.SueTypeNumber,
				SurStatus = checkData.SurStatus,
				AppUserId = checkData.AppUserId,
				SueDetailsId = checkData.SueDetailsId,
				AddedBy = checkData.AddedBy,
				IsStatus = checkData.IsStatus,
				CreatedDate = checkData.CreatedDate,
				ModifiedDate=checkData.ModifiedDate,
				RemovedDate=checkData.RemovedDate,
				ModifiedBy=checkData.ModifiedBy,
				RemovedBy=checkData.ModifiedBy,
				
			};
			return new BaseResponse<SueResponse>(map, true, "SUE :");
		}

		public BaseResponse<SueResponse> GetSueFilter(FilterSueRequest request)
		{
			var query = _sueReadRepository.GetAll();
			if (request.SurStatus.HasValue)
			{
				query = query.Where(x => x.SurStatus == request.SurStatus);
			}
			if (request.AppUserId.HasValue)
			{
				query = query.Where(x => x.AppUserId == request.AppUserId);
			}
			if (request.SueDetailsId.HasValue)
			{
				query = query.Where(x => x.SueDetailsId == request.SueDetailsId);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new SueResponse
			{
				RemovedDate = x.RemovedDate,
				SueDetailsId = x.SueDetailsId,
				AddedBy = x.AddedBy,
				AppUserId = x.AppUserId,
				CreatedDate = x.CreatedDate,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				RemovedBy = x.RemovedBy,
				SueNumber = x.SueNumber,
				SueTypeNumber = x.SueTypeNumber,
				SurStatus = x.SurStatus
			}).FirstOrDefault();
				if(response is null)
			{
				return new BaseResponse<SueResponse>(false, "SUE NOT FOUND");
			}
			return new BaseResponse<SueResponse>(response,true, "SUE");
		}

		public async Task<BaseResponse<bool>> UpdateSue(UpdateSueRequest request)
		{
			var checkData = await _sueReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "SUE NOT FOUND");
			}
			checkData.SueNumber=request.SueNumber;
			checkData.SueTypeNumber=request.SueTypeNumber;
			checkData.SurStatus=request.SurStatus;
			checkData.AppUserId=request.AppUserId;
			checkData.SueDetailsId=request.SueDetailsId;
			checkData.ModifiedBy=request.ModifiedBy;
			checkData.IsStatus=request.IsStatus;
			checkData.ModifiedDate = DateTime.UtcNow;
			var response= _sueWriteRepository.Update(checkData);
			var save = await _sueWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Sue Updating Operation Failed");
			}
			return new BaseResponse<bool>(true, "Sue Updating Operation SUCCESS");
		}
	}
}
