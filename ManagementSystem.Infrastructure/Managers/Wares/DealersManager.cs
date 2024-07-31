using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Wares.Dealer;
using MagamentSystem.Application.Managers.Wares;
using MagamentSystem.Application.Repository.WaresRepository.Dealaers;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Managers.Wares
{
	public class DealersManager : IDealersManager
	{
		private readonly IDealerReadRepository _dealerReadRepository;
		private readonly IDealerWriteRepository _dealerWriteRepository;
		

		public DealersManager(IDealerReadRepository dealerReadRepository, IDealerWriteRepository dealerWriteRepository)
		{
			_dealerReadRepository = dealerReadRepository;
			_dealerWriteRepository = dealerWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateDealers(CreateDealerRequest request)
		{
			Dealer map = new Dealer
			{
				IsStatus = request.IsStatus,
				Location=request.Location,
				Email=request.Email,
				AddedBy=request.AddedBy,
				CreatedDate=DateTime.UtcNow,
				Name= request.Name,
				Phone= request.Phone,
				
				
			};
			var response= await _dealerWriteRepository.AddAsync(map);
			var save = await _dealerWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Dealer Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Deaeler Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteDealers(RemoveDealerRequest request)
		{
			var checkData = await _dealerReadRepository.GetSingleById(request.Id);
			if(checkData is null){
				return new BaseResponse<bool>(false, "Dealer NOT FOUND"); 
			}
			checkData.RemovedBy = request.RemovedBy;
			checkData.RemovedDate = DateTime.UtcNow;
			var response = _dealerWriteRepository.Remove(checkData);
			var save = await _dealerWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Dealer Removed Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Dealer Removed Operation SUCCESSL");
		}

		public BaseResponse<List<DealerResponse>> GetAllDealers()
		{
			var datas = _dealerReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			if (datas is null)
			{
				return new BaseResponse<List<DealerResponse>>(false, "Dealer LIST is EMPTY");
			}
			List<DealerResponse> result = new List<DealerResponse>();
			foreach (var data in datas)
			{
				DealerResponse dr = new DealerResponse
				{
					AddedBy = data.Id,
					CreateDate=data.CreatedDate,
					Email = data.Email,
					Id = data.Id,
					Location = data.Location,
					ModifiedBy = data.ModifiedBy,
					ModifiedDate= data.ModifiedDate,
					Name = data.Name,
					Phone = data.Phone,
					RemovedBy = data.RemovedBy,
					RemovedDate = data.RemovedDate
				};
				result.Add(dr);
			}
			return new BaseResponse<List<DealerResponse>>(result, true, "Dealer LIST");
		
		
		}


		public BaseResponse<List<DealerResponse>> GetAllDealersFilter(FilterDealerRequest request)
		{
			var query = _dealerReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Name))
			{
				query = query.Where(x => x.Name.Contains(request.Name));
			}
			if (!string.IsNullOrEmpty(request.Location))
			{
				query=query.Where(x=>x.Location.Contains(request.Location));
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new DealerResponse
			{
				RemovedDate = x.RemovedDate,
				Name = x.Name,
				AddedBy = x.AddedBy,
				CreateDate = x.CreatedDate,
				Email = x.Email,
				Id = x.Id,
				Location = x.Location,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Phone = x.Phone,
				RemovedBy = x.RemovedBy
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<DealerResponse>>(false,"Dealer LIST is EMPTY");
			}
			return new BaseResponse<List<DealerResponse>>(response,true,"Dealer LIST:");
		}

		public async Task<BaseResponse<DealerResponse>> GetDealersById(int id)
		{
			var checkData = await _dealerReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<DealerResponse>(false, "Dealer NOT FOUND");
			}
			DealerResponse ds = new DealerResponse
			{
				RemovedDate=checkData.RemovedDate,
				RemovedBy=checkData.RemovedBy,
				Phone=checkData.Phone,
				Name=checkData.Name,
				ModifiedDate=checkData.ModifiedDate,
				ModifiedBy=checkData.ModifiedBy,
				Location=checkData.Location,
				AddedBy= checkData.AddedBy,
				CreateDate=checkData.CreatedDate,
				Email=checkData.Email,

			};
			return new BaseResponse<DealerResponse>(ds, true, "Dealer :");
		}

		public BaseResponse<DealerResponse> GetDealersFilter(FilterDealerRequest request)
		{
			var query = _dealerReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Name))
			{
				query = query.Where(x => x.Name.Contains(request.Name));
			}
			if (!string.IsNullOrEmpty(request.Location))
			{
				query = query.Where(x => x.Location.Contains(request.Location));
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new DealerResponse
			{
				RemovedDate = x.RemovedDate,
				Name = x.Name,
				AddedBy = x.AddedBy,
				CreateDate = x.CreatedDate,
				Email = x.Email,
				Id = x.Id,
				Location = x.Location,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Phone = x.Phone,
				RemovedBy = x.RemovedBy
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<DealerResponse>(false, "Dealer NOT FOUND");
			}
			return new BaseResponse<DealerResponse>(response, true, "Dealer");
		}

		public async Task<BaseResponse<bool>> UpdateDealers(UpdateDealerRequest request)
		{
			var checkData= await _dealerReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Dealer NOT FOUND");
			}
			checkData.Location = request.Location;
			checkData.ModifiedBy = request.ModifiedBy;
			checkData.ModifiedDate = DateTime.UtcNow;
			checkData.Name = request.Name;	
			checkData.Email = request.Email;
			checkData.Phone= request.Phone;
			checkData.IsStatus = request.IsStatus;
			
			var response= _dealerWriteRepository.Update(checkData);
			var save = await _dealerWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Dealer Update Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Dealer Update Operation SUCCESS");
		}
	}
}
