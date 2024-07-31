using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.Managers.Buy;
using MagamentSystem.Application.Repository.BuyRepository.ContractInfos;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Managers.Buy
{
	public class ContractInfoManager : IContractInfoManager
	{
		private readonly IContractInfoReadRepository _contractInfoReadRepository;
		private readonly IContractInfoWriteRepository _contractInfoWriteRepository;
		

		public ContractInfoManager(IContractInfoReadRepository contractInfoReadRepository, IContractInfoWriteRepository contractInfoWriteRepository)
		{
			_contractInfoReadRepository = contractInfoReadRepository;
			_contractInfoWriteRepository = contractInfoWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateContractInfo(CreateContractInfoRequest request)
		{
			ContractInfo map = new ContractInfo
			{
				ContractAmount=request.ContractAmount,
				ContractName=request.ContractName,
				ContractNo=request.ContractNo,
				StartedDate=request.StartedDate,
				EndDate=request.EndDate,
				Currency=request.Currency,
				SueDetailsId=request.SueDetailsId,
				AddedBy=request.AddedBy,
				CreatedDate=DateTime.UtcNow,
				IsStatus=request.IsSuccess
			};
			var response= await _contractInfoWriteRepository.AddAsync(map);
			var save = await _contractInfoWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Contract Info Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Contract Info Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteContractInfo(RemoveContractİnfoRequest request)
		{
			var checkData = await _contractInfoReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Contract Info NOT FOUND");
			}
			checkData.RemovedDate = DateTime.UtcNow;
			//checkData.RemovedBy=request.Id;
			var update =  _contractInfoWriteRepository.Remove(checkData);
			var save = await _contractInfoWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Contract Info Removed Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Contract Info Removed Operation SUCCESS");

		}

		public BaseResponse<List<ContractInfoResponse>> GetAllContractInfo()
		{
			var datas = _contractInfoReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			if(datas is null)
			{
				return new BaseResponse<List<ContractInfoResponse>>(false, "Contract Info NOT FOUND");
			}
			List<ContractInfoResponse> map = new List<ContractInfoResponse>();
			foreach (var data in datas)
			{
				ContractInfoResponse mapTO = new ContractInfoResponse
				{
					Id=data.Id,
					ContractAmount=data.ContractAmount,
					ContractName=data.ContractName,
					ContractNo=data.ContractNo,
					StartedDate=data.StartedDate,
					EndDate=data.EndDate,
					Currency=data.Currency,
					SueDetailsId=data.SueDetailsId,	
					AddedBy=data.AddedBy,
					ModifiedBy=data.ModifiedBy,
					RemovedBy=data.RemovedBy,
					IsSuccess=data.IsStatus,
					CreatedDate=data.CreatedDate,
					ModifiedDate=data.ModifiedDate,
					RemovedDate= data.RemovedDate	
				};
				map.Add(mapTO);
			}
			return new BaseResponse<List<ContractInfoResponse>>(map, true, "Contract Info LIST :");
		}

		public BaseResponse<List<ContractInfoResponse>> GetAllContractInfoFilter(FilterContractİnfoRequest request)
		{
			var query = _contractInfoReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.ContractName))
			{
				query=query.Where(x=> x.ContractName.Contains(request.ContractName));
			}
			if (!string.IsNullOrEmpty(request.ContractNo))
			{
				query=query.Where(x=> x.ContractNo.Contains(request.ContractNo));	
			}
			if (!string.IsNullOrEmpty(request.Currency))
			{
				query=query.Where(x=>x.Currency.Contains(request.Currency));
			}
			if (request.SueDetailsId.HasValue)
			{
				query=query.Where(x=> x.SueDetailsId == request.SueDetailsId.Value);
			}
			var response = query.Where(x=>x.RemovedDate==null).Select(x => new ContractInfoResponse
			{
				AddedBy=x.AddedBy,
				StartedDate=x.StartedDate,
				SueDetailsId=x.SueDetailsId,
				RemovedBy=x.RemovedBy,
				RemovedDate=x.RemovedDate,
				ContractAmount=x.ContractAmount,
				ContractName=x.ContractName,
				ContractNo=x.ContractNo,
				CreatedDate=x.CreatedDate,
				Currency=x.Currency,
				EndDate=x.EndDate,
				Id=x.Id,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate=x.ModifiedDate,
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<ContractInfoResponse>>(false, "Contract Info NOT FOUND");
			}
			return new BaseResponse<List<ContractInfoResponse>>(response, true, "Contract INFO LIST:");
		}

		public async Task<BaseResponse<ContractInfoResponse>> GetContractInfoById(int id)
		{
			var checkData = await _contractInfoReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ContractInfoResponse>(false, "Contract Info NOT FOUND");
			}
			ContractInfoResponse map = new ContractInfoResponse
			{
				Id = checkData.Id,
				ContractAmount = checkData.ContractAmount,
				ContractName = checkData.ContractName,
				ContractNo = checkData.ContractNo,
				StartedDate = checkData.StartedDate,
				EndDate = checkData.EndDate,
				Currency = checkData.Currency,
				SueDetailsId = checkData.SueDetailsId,
				AddedBy = checkData.AddedBy,
				ModifiedBy = checkData.ModifiedBy,
				RemovedBy = checkData.RemovedBy,
				IsSuccess = checkData.IsStatus,
				CreatedDate = checkData.CreatedDate,
				ModifiedDate = checkData.ModifiedDate,
				RemovedDate = checkData.RemovedDate
			};
			return new BaseResponse<ContractInfoResponse>(map, true, "Contract INFO:");
		}

		public BaseResponse<ContractInfoResponse> GetContractInfoFilter(FilterContractİnfoRequest request)
		{
			var query = _contractInfoReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.ContractName))
			{
				query = query.Where(x => x.ContractName.Contains(request.ContractName));
			}
			if (!string.IsNullOrEmpty(request.ContractNo))
			{
				query = query.Where(x => x.ContractNo.Contains(request.ContractNo));
			}
			if (!string.IsNullOrEmpty(request.Currency))
			{
				query = query.Where(x => x.Currency.Contains(request.Currency));
			}
			if (request.SueDetailsId.HasValue)
			{
				query = query.Where(x => x.SueDetailsId == request.SueDetailsId.Value);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new ContractInfoResponse
			{
				AddedBy = x.AddedBy,
				StartedDate = x.StartedDate,
				SueDetailsId = x.SueDetailsId,
				RemovedBy = x.RemovedBy,
				RemovedDate = x.RemovedDate,
				ContractAmount = x.ContractAmount,
				ContractName = x.ContractName,
				ContractNo = x.ContractNo,
				CreatedDate = x.CreatedDate,
				Currency = x.Currency,
				EndDate = x.EndDate,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<ContractInfoResponse>(false, "Contract Info NOT FOUND");
			}
			return new BaseResponse<ContractInfoResponse>(response, true, "Contract INFO");
		}

		public async Task<BaseResponse<bool>> UpdateContractInfo(UpdateContractİnfoRequest request)
		{
			var checkData = await _contractInfoReadRepository.GetSingleById(request.Id);
			if (checkData is null)
			{
				return new BaseResponse<bool>(false, "Contract Info NOT FOUND");
			}
			checkData.ContractName=request.ContractName;
			checkData.ContractNo=request.ContractNo;
			checkData.StartedDate=request.StartedDate;
			checkData.EndDate=request.EndDate;
			checkData.ContractAmount=request.ContractAmount;
			checkData.Currency=request.Currency;
			checkData.SueDetailsId=request.SueDetailsId;
			checkData.ModifiedBy=request.ModifiedBy;
			checkData.IsStatus=request.IsStatus;
			checkData.ModifiedDate = DateTime.UtcNow;
			var response = _contractInfoWriteRepository.Update(checkData);
			var save = await _contractInfoWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Contract Info Update Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Contract Info Update Operation SUCCESS");
		}

	}
}
