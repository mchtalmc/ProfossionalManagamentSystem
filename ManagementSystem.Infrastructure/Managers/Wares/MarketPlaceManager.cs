using AutoMapper;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.DataTransferObject.Wares.MarketPlace;
using MagamentSystem.Application.Managers.Wares;
using MagamentSystem.Application.Repository.WaresRepository.MarketPlaces;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Managers.Wares
{
	public class MarketPlaceManager : IMarketPlaceManager

	{
		private readonly IMarketPlaceReadRepository _marketPlaceReadRepository;
		private readonly IMarketPlaceWriteRepository _marketPlaceWriteRepository;
		

		public MarketPlaceManager(IMarketPlaceReadRepository marketPlaceReadRepository, IMarketPlaceWriteRepository marketPlaceWriteRepository)
		{
			_marketPlaceReadRepository = marketPlaceReadRepository;
			_marketPlaceWriteRepository = marketPlaceWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateMarketPlace(CraeteMarketPlaceRequest request)
		{
			MarketPlace map = new MarketPlace
			{
				IsStatus = request.IsStatus,
				AddedBy = request.AddedBy,
				Capacity = request.Capacity,
				CreatedDate=DateTime.UtcNow,
				Location= request.Location,
				Name= request.Name,
				
			};
			var response= await _marketPlaceWriteRepository.AddAsync(map);
			var save = await _marketPlaceWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Market Place Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Market Place Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteMarketPlace(RemoveMarketPlaceRequest request)
		{
			var checkData = await _marketPlaceReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Market Place NOT FOUND");
			}
			checkData.RemovedDate = DateTime.UtcNow;
			checkData.RemovedBy = request.RemovedBy;
			var update = _marketPlaceWriteRepository.Update(checkData);
			var save= await _marketPlaceWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Market Place Remove Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Market Place Remove  Operation SUCCESS");
		}

		public BaseResponse<List<MarketPlaceResponse>> GetAllMarketPlace()
		{
			var datas = _marketPlaceReadRepository.GetAll().Where(x => x.RemovedDate == null);
			if(datas is null)
			{
				return new BaseResponse<List<MarketPlaceResponse>>(false, "Market Place List is EMPTY");
			}
			List<MarketPlaceResponse> mapTO = new List<MarketPlaceResponse>();
			foreach (var data in datas)
			{
				MarketPlaceResponse map = new MarketPlaceResponse
				{
					Name = data.Name,
					Location = data.Location,
					ModifiedBy= data.ModifiedBy,
					AddedBy=data.AddedBy,
					ModifiedDate=data.ModifiedDate,
					RemovedBy= data.RemovedBy,
					CreatedDate= data.CreatedDate,
					RemovedDate= data.RemovedDate,
					IsStatus= data.IsStatus,
					Capacity = data.Capacity,
				};
				mapTO.Add(map);
			}
			
			return new BaseResponse<List<MarketPlaceResponse>>(mapTO, true, "Market Place List:");
		
		}

		public BaseResponse<List<MarketPlaceResponse>> GetAllMarketPlaceFilter(FilterMarketPlaceRequest request)
		{
			var query = _marketPlaceReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Location))
			{
				query = query.Where(x => x.Location.Contains(request.Location));
			}
			if (request.Capacity.HasValue)
			{
				query=query.Where(x=>x.Capacity == request.Capacity);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new MarketPlaceResponse
			{
				RemovedDate = x.RemovedDate,
				Capacity = x.Capacity,
				AddedBy=x.AddedBy,
				CreatedDate = x.CreatedDate,
				Id = x.Id,
				Location = x.Location,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Name = x.Name,
				RemovedBy = x.RemovedBy
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<MarketPlaceResponse>>(false, "Market Place List is EMPTY");
			}
			return new BaseResponse<List<MarketPlaceResponse>>(response, true, "Market Place LIST:");
		}

		public async Task<BaseResponse<MarketPlaceResponse>> GetMarketPlaceById(int id)
		{
			var checkData = await _marketPlaceReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<MarketPlaceResponse>(false, "Market Place NOT FOUND");
			}
			MarketPlaceResponse mpr = new MarketPlaceResponse
			{
				Capacity=checkData.Capacity,
				IsStatus=checkData.IsStatus,
				RemovedDate=checkData.RemovedDate,
				CreatedDate=checkData.CreatedDate,
				RemovedBy = checkData.RemovedBy,
				AddedBy= checkData.AddedBy,
				Id=checkData.Id,
				Location=checkData.Location,
				ModifiedBy = checkData.ModifiedBy,
				ModifiedDate=checkData.ModifiedDate,
				Name= checkData.Name,
				
			};
			return new BaseResponse<MarketPlaceResponse>(mpr, true, "Market Place :");
		}

		public BaseResponse<MarketPlaceResponse> GetMarketPlaceFilter(FilterMarketPlaceRequest request)
		{
			var query = _marketPlaceReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Location))
			{
				query = query.Where(x => x.Location.Contains(request.Location));
			}
			if (request.Capacity.HasValue)
			{
				query = query.Where(x => x.Capacity == request.Capacity);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new MarketPlaceResponse
			{
				RemovedDate = x.RemovedDate,
				Capacity = x.Capacity,
				AddedBy = x.AddedBy,
				CreatedDate = x.CreatedDate,
				Id = x.Id,
				Location = x.Location,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Name = x.Name,
				RemovedBy = x.RemovedBy
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<MarketPlaceResponse>(false, "Market Place NOT FOUN");
			}
			return new BaseResponse<MarketPlaceResponse>(response, true, "Market Place :");
		}

		public async Task<BaseResponse<bool>> UpdateMarketPlace(UpdateMarketPlaceRequest request)
		{
			var checkData = await _marketPlaceReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Market Place NOT FOUND");
			}
			checkData.Location= request.Location;
			checkData.ModifiedDate = DateTime.UtcNow;
			checkData.Capacity=request.Capacity;
			checkData.ModifiedBy= request.ModifiedBy;
			checkData.IsStatus = request.IsStatus;
			var update = _marketPlaceWriteRepository.Update(checkData);
			var save = await _marketPlaceWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Market Place Update Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Market Place Update Operation SUCCESS");
		}
	}
}
