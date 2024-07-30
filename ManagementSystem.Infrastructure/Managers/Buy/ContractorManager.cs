using AutoMapper;
using Azure.Core;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractor;
using MagamentSystem.Application.DataTransferObject.User.AppUser;
using MagamentSystem.Application.Managers.Buy;
using MagamentSystem.Application.Repository.BuyRepository.Contractors;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Managers.Buy
{
	public class ContractorManager : IContractorManager
	{
		private readonly IContractorReadRepository _contractReadRepository;
		private readonly IContractorWriteRepository _contractWriteRepository;
		

		public ContractorManager(IContractorReadRepository contractReadRepository, IContractorWriteRepository contractWriteRepository)
		{
			_contractReadRepository = contractReadRepository;
			_contractWriteRepository = contractWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateContractor(CreateContractorRequest request)
		{
			Contractor mapData = new Contractor
			{
				Name=request.Name,
				ContractorCode=request.ContractorCode,
				Address=request.Address,
				PhoneNumber=request.PhoneNumber,
				Email=request.Email,
				SueDetailsId=request.SueDetailsId,
				AddedBy=request.AddedBy,
				CreatedDate=DateTime.UtcNow,
				IsStatus=request.IsSuccess
			};
			var response= await _contractWriteRepository.AddAsync(mapData);
			var save = await _contractWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Contractor Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Contractor Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteContractor(RemoveContractorRequest request)
		{
			var checkData = await _contractReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Contractor NOT FOUND");
			}
			checkData.RemovedDate = DateTime.UtcNow;
			//checkData.RemovedBy= ??
			var update = _contractWriteRepository.Update(checkData);
			var save= await _contractWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Contractor Update Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Contracotr Update Operation SUCCESS");
		}

		public BaseResponse<List<ContractorResponse>> GetAllContractor()
		{
			var datas = _contractReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			if(datas is null)
			{
				return new BaseResponse<List<ContractorResponse>>(false, " Contractor List EMPTY");
			}
			List<ContractorResponse> map = new List<ContractorResponse>();
			foreach (var data in datas)
			{
				ContractorResponse mapTo = new ContractorResponse
				{
					Id=data.Id,
					Name=data.Name,
					ContractorCode=data.ContractorCode,
					Address=data.Address,
					PhoneNumber=data.PhoneNumber,
					Email=data.Email,
					SueDetailsId=data.SueDetailsId,
					AddedBy=data.AddedBy,
					ModifiedBy=data.ModifiedBy,
					RemovedBy=data.RemovedBy,
					IsStatus = data.IsStatus,
					CreatedDate=data.CreatedDate,
					ModifiedDate=data.ModifiedDate,
					RemovedDate=data.ModifiedDate,
				};
				map.Add(mapTo);
			}
			return new BaseResponse<List<ContractorResponse>>(map, true, "Contractor LIST :");
		}

		public BaseResponse<List<ContractorResponse>> GetAllContractorFilter(FilterContractorRequest request)
		{
			var query = _contractReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Name))
			{
				query=query.Where(x=> x.Name.Contains(request.Name));
			}
			if (!string.IsNullOrEmpty(request.Address))
			{
				query=query.Where(x=> x.Address.Contains(request.Address));
			}
			if (!string.IsNullOrEmpty(request.Email))
			{
				query=query.Where(x=> x.Email.Contains(request.Email));	
			}
			if (request.SueDetailsId.HasValue)
			{
				query=query.Where(x=> x.SueDetailsId== request.SueDetailsId.Value);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new ContractorResponse
			{
				RemovedDate = x.RemovedDate,
				AddedBy=x.AddedBy,
				Address=x.Address,
				ContractorCode=x.ContractorCode,
				CreatedDate=x.CreatedDate,
				Email=x.Email,
				Id=x.Id,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate=x.ModifiedDate,
				Name=x.Name,
				PhoneNumber=x.PhoneNumber,
				RemovedBy=x.RemovedBy,
				SueDetailsId = x.SueDetailsId,
				
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<ContractorResponse>>(false, "Contractor LIST is EMPTY");
			}
			return new BaseResponse<List<ContractorResponse>>(response, true, "Contractor LIST");
		}

		public async Task<BaseResponse<ContractorResponse>> GetContractorById(int id)
		{
			var checkData = await _contractReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ContractorResponse>(false, "Contractor NOT FOUND");
			}
			ContractorResponse map = new ContractorResponse
			{
				Id=checkData.Id,
				Name = checkData.Name,
				ContractorCode = checkData.ContractorCode,
				Address = checkData.Address,
				PhoneNumber = checkData.PhoneNumber,
				Email = checkData.Email,
				SueDetailsId = checkData.SueDetailsId,
				AddedBy = checkData.AddedBy,
				CreatedDate = checkData.CreatedDate,
				IsStatus = checkData.IsStatus,
				RemovedDate = checkData.RemovedDate,
				ModifiedDate = checkData.ModifiedDate,
				ModifiedBy = checkData.ModifiedBy,
				RemovedBy=checkData.RemovedBy,
				
			};
			return new BaseResponse<ContractorResponse>(map, true, "Contrator :");
		}

		public BaseResponse<ContractorResponse> GetContractorFilter(FilterContractorRequest request)
		{
			var query = _contractReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Name))
			{
				query = query.Where(x => x.Name.Contains(request.Name));
			}
			if (!string.IsNullOrEmpty(request.Address))
			{
				query = query.Where(x => x.Address.Contains(request.Address));
			}
			if (!string.IsNullOrEmpty(request.Email))
			{
				query = query.Where(x => x.Email.Contains(request.Email));
			}
			if (request.SueDetailsId.HasValue)
			{
				query = query.Where(x => x.SueDetailsId == request.SueDetailsId.Value);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new ContractorResponse
			{
				RemovedDate = x.RemovedDate,
				AddedBy = x.AddedBy,
				Address = x.Address,
				ContractorCode = x.ContractorCode,
				CreatedDate = x.CreatedDate,
				Email = x.Email,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Name = x.Name,
				PhoneNumber = x.PhoneNumber,
				RemovedBy = x.RemovedBy,
				SueDetailsId = x.SueDetailsId,

			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<ContractorResponse>(false, "Contractor NOT FOUND");
			}
			return new BaseResponse<ContractorResponse>(response, true, "Contractor :");
			
		}

		public async Task<BaseResponse<bool>> UpdateContractor(UpdateContractorRequest request)
		{
			var checkData = await _contractReadRepository.GetSingleById(request.Id);

			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Contractor NOT FOUND");
			}
			checkData.Name=request.Name;
			checkData.ContractorCode=request.ContractorCode;
			checkData.Address = request.Address;
			checkData.PhoneNumber=request.PhoneNumber;
			checkData.Email=request.Email;
			checkData.SueDetailsId=request.SueDetailsId;
			checkData.ModifiedBy=request.ModifiedBy;
			checkData.ModifiedDate = DateTime.UtcNow;
			var response= _contractWriteRepository.Update(checkData);
			var save = await _contractWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Contractor Updating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Contractor Updating Operation SUCCESS");

		}
	}
}
