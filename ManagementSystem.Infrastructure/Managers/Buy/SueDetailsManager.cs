using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.SueDetails;
using MagamentSystem.Application.Managers.Buy;
using ManagamentSystem.Core.Entities.Buy;
using ManagementSystem.Infrastructure.Repository.Buy.SueDetails;

namespace ManagementSystem.Infrastructure.Managers.Buy
{
	public class SueDetailsManager : ISueDetailManager
	{
		private readonly SueDetailsReadRepository _sueDetailsReadRepository;
		private readonly SueDetailsWriteRepository _sueDetailsWriteRepository;
		

		public SueDetailsManager(SueDetailsReadRepository sueDetailsReadRepository, SueDetailsWriteRepository sueDetailsWriteRepository)
		{
			_sueDetailsReadRepository = sueDetailsReadRepository;
			_sueDetailsWriteRepository = sueDetailsWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateSueDetails(CreateSueDetailsRequest request)
		{
			SueDetails map = new SueDetails
			{
				Location = request.Location,
				Quantity=request.Quantity,
				Currency=request.Currency,
				UnitPrice=request.UnitPrice,
				Cost=request.Cost,
				Description=request.Description,
				DeliveryLocation=request.DeliveryLocation,
				JobName=request.JobName,
				StartedDate=request.StartedDate,
				EndDate=request.EndDate,
				ProductId=request.ProductId,
				AddedBy=request.AddedBy,
				CreatedDate=DateTime.UtcNow
			};
			var response= await _sueDetailsWriteRepository.AddAsync(map);
			var save = await _sueDetailsWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Sue Details Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Sue Details Creating Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteSueDetails(RemoveSueDetailsRequest request)
		{
			var checkData = await _sueDetailsReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Sue Details NOT FOUND");
			}
			checkData.RemovedBy= request.Id;
			checkData.RemovedDate = DateTime.UtcNow;
			var response = _sueDetailsWriteRepository.Update(checkData);
			var save= await _sueDetailsWriteRepository.Save();
			if(save <0)
			{
				return new BaseResponse<bool>(false, "Sue Details Removing Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Sue Details Removing Operation SUCCESS");
		}

		public BaseResponse<List<SueDetailsReponse>> GetAllSueDetails()
		{
			var datas = _sueDetailsReadRepository.GetAll().Where(x => x.RemovedDate == null);
			if(datas is null)
			{
				return new BaseResponse<List<SueDetailsReponse>>(false, "Sue Details LIST is EMPTY");
			}
			List<SueDetailsReponse> map  = new List<SueDetailsReponse>();
			foreach (var sueDetails in datas)
			{
				SueDetailsReponse mapTo = new SueDetailsReponse
				{
					Id= sueDetails.Id,
					Location= sueDetails.Location,
					Quantity= sueDetails.Quantity,
					Currency= sueDetails.Currency,
					UnitPrice= sueDetails.UnitPrice,
					Cost= sueDetails.Cost,
					Description= sueDetails.Description,
					DeliveryLocation= sueDetails.DeliveryLocation,
					JobName= sueDetails.JobName,
					StartedDate= sueDetails.StartedDate,
					EndDate= sueDetails.EndDate,
					ProductId= sueDetails.ProductId,
					AddedBy=sueDetails.AddedBy,
					ModifiedBy=sueDetails.ModifiedBy,
					RemovedBy=sueDetails.RemovedBy,
					IsStatus= sueDetails.IsStatus,
					CreatedDate= sueDetails.CreatedDate,
					ModifiedDate= sueDetails.ModifiedDate,
					RemovedDate= sueDetails.RemovedDate,
				};
				map.Add(mapTo);
			}
			return new BaseResponse<List<SueDetailsReponse>>(map, true, "Sue Details LIST :");
		}

		public BaseResponse<List<SueDetailsReponse>> GetAllSueDetailsFilter(FilterSueDetailsRequest request)
		{
			var query = _sueDetailsReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Location))
			{
				query=query.Where(x=>x.Location.Contains(request.Location));
			}
			if (request.Quantity.HasValue)
			{
				query=query.Where(x=> x.Quantity==request.Quantity);

			}
			if (!string.IsNullOrEmpty(request.Currency))
			{
				query=query.Where(x=> x.Currency.Contains(request.Currency));
			}
			if (request.UnitPrice.HasValue)
			{
				query=query.Where(x=> x.UnitPrice==request.UnitPrice);	
			}
			if(request.Cost.HasValue)
			{
				query=query.Where(x=>x.Cost==request.Cost);
			}
			if (!string.IsNullOrEmpty(request.DeliveryLocation))
			{
				query=query.Where(x=>x.DeliveryLocation.Contains(request.DeliveryLocation));
			}
			if(!string.IsNullOrEmpty(request.JobName))
			{
				query=query.Where(x=>x.JobName.Contains(request.JobName));
			}
			if (request.ProductId.HasValue)
			{
				query=query.Where(x=>x.ProductId==request.ProductId);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new SueDetailsReponse
			{
				RemovedDate = x.RemovedDate,
				RemovedBy = x.RemovedBy,
				AddedBy=x.AddedBy,	
				Cost=x.Cost,
				DeliveryLocation=x.DeliveryLocation,
				CreatedDate=x.CreatedDate,
				Currency=x.Currency,
				Description	= x.Description,
				EndDate=x.EndDate,
				Id=x.Id,
				JobName=x.JobName,
				  Location=x.Location,
				  ModifiedBy=x.ModifiedBy,
				  ModifiedDate=x.ModifiedDate,
				  ProductId=x.ProductId,
				  Quantity=x.Quantity,
				  StartedDate=x.StartedDate,
				  UnitPrice = x.UnitPrice
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<SueDetailsReponse>>(false, "Sue Details List is EMPTY :");
			}
			return new BaseResponse<List<SueDetailsReponse>>(response, true, "Sue Details LIST :");
		}

		public async Task<BaseResponse<SueDetailsReponse>> GetSueDetailsById(int id)
		{
			var checkData = await _sueDetailsReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<SueDetailsReponse>(false, " Sue Details NOT FOUND");
			}
			SueDetailsReponse map = new SueDetailsReponse
			{
				Id=checkData.Id,
				Location = checkData.Location,
				Quantity = checkData.Quantity,
				Currency = checkData.Currency,
				UnitPrice = checkData.UnitPrice,
				Cost = checkData.Cost,
				Description = checkData.Description,
				DeliveryLocation = checkData.DeliveryLocation,
				JobName = checkData.JobName,
				StartedDate = checkData.StartedDate,
				EndDate = checkData.EndDate,
				ProductId = checkData.ProductId,
				AddedBy = checkData.AddedBy,
				CreatedDate = DateTime.UtcNow
			};
			return new BaseResponse<SueDetailsReponse>(map, true, "Sue Details :");
		}

		public BaseResponse<SueDetailsReponse> GetSueDetailsFilter(FilterSueDetailsRequest request)
		{
			var query = _sueDetailsReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Location))
			{
				query = query.Where(x => x.Location.Contains(request.Location));
			}
			if (request.Quantity.HasValue)
			{
				query = query.Where(x => x.Quantity == request.Quantity);

			}
			if (!string.IsNullOrEmpty(request.Currency))
			{
				query = query.Where(x => x.Currency.Contains(request.Currency));
			}
			if (request.UnitPrice.HasValue)
			{
				query = query.Where(x => x.UnitPrice == request.UnitPrice);
			}
			if (request.Cost.HasValue)
			{
				query = query.Where(x => x.Cost == request.Cost);
			}
			if (!string.IsNullOrEmpty(request.DeliveryLocation))
			{
				query = query.Where(x => x.DeliveryLocation.Contains(request.DeliveryLocation));
			}
			if (!string.IsNullOrEmpty(request.JobName))
			{
				query = query.Where(x => x.JobName.Contains(request.JobName));
			}
			if (request.ProductId.HasValue)
			{
				query = query.Where(x => x.ProductId == request.ProductId);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new SueDetailsReponse
			{
				RemovedDate = x.RemovedDate,
				RemovedBy = x.RemovedBy,
				AddedBy = x.AddedBy,
				Cost = x.Cost,
				DeliveryLocation = x.DeliveryLocation,
				CreatedDate = x.CreatedDate,
				Currency = x.Currency,
				Description = x.Description,
				EndDate = x.EndDate,
				Id = x.Id,
				JobName = x.JobName,
				Location = x.Location,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				ProductId = x.ProductId,
				Quantity = x.Quantity,
				StartedDate = x.StartedDate,
				UnitPrice = x.UnitPrice
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<SueDetailsReponse>(false, "Sue Details NOT FOUND");
			}
			return new BaseResponse<SueDetailsReponse>(response, true, "Sue DETAIL :");
		}

		public async Task<BaseResponse<bool>> UpdateSueDetails(UpdateSueDetailsRequest request)
		{
			var checkData = await _sueDetailsReadRepository.GetSingleById(request.Id);
            if (checkData is null)
            {
				return new BaseResponse<bool>(false, "Sue Detaisl NOT FOUND");
            }
			checkData.Location= request.Location;
			checkData.Quantity=request.Quantity;
			checkData.UnitPrice=request.UnitPrice;
			checkData.Cost = request.Cost;
			checkData.Description=request.Description;
			checkData.DeliveryLocation= request.DeliveryLocation;
			checkData.JobName=request.JobName;
			checkData.StartedDate= request.StartedDate;
			checkData.EndDate= request.EndDate;
			checkData.ProductId= request.ProductId;
			checkData.ModifiedBy= request.ModifiedBy;
			checkData.ModifiedDate = DateTime.UtcNow;
			var response= _sueDetailsWriteRepository.Update(checkData);
			var save = await _sueDetailsWriteRepository.Save();
			if(save <0)
			{
				return new BaseResponse<bool>(false, "Sue Details Updating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Sue Details Updating Operation SUCCESS");
        }
	}
}
