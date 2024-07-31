using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Military;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Repository.UserRepository.Military;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Managers.User
{
	public class MilitaryManager : IMilitaryManager
	{
		private readonly IMilitaryReadRepository _militaryReadRepository;
		private readonly IMilitaryWriteRepository _militaryWriteRepository;
		

		public MilitaryManager( IMilitaryWriteRepository militaryWriteRepository, IMilitaryReadRepository militaryReadRepository)
		{

			
			_militaryWriteRepository = militaryWriteRepository;
			_militaryReadRepository = militaryReadRepository;
		}

		public async Task<BaseResponse<bool>> CreateMilitaryStatus(CreateMilitaryRequest request)
		{
			MilitaryStatus mapData = new MilitaryStatus
			{
				AppUserId= request.AppUserId,
				IsStatus=request.IsStatus,
				IsDone=request.IsDone,
				Delay=request.Delay,
				DelayEndDate=request.DelayEndDate,
				EndDate=request.EndDate,
				AddedBy=request.AddedBy,
				CreatedDate=DateTime.UtcNow
			};
			var response = await _militaryWriteRepository.AddAsync(mapData);
			var save = await _militaryWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Military Innformation Create Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Military Information Create Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteMilitaryStatus(RemoveMilitaryRequest request)
		{
			var checkData = await _militaryReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Military Information NOT FOUND");
			}
			checkData.RemovedBy = request.RemovedBy;
			checkData.RemovedDate = DateTime.UtcNow;
			var update = _militaryWriteRepository.Update(checkData);
			var save = await _militaryWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Military Information REMOVE Operation IS FAILED");
			}
			return new BaseResponse<bool>(true, "Military Information Remove Operation IS SUCCESS");
		}

		public BaseResponse<List<MilitaryResponse>> GetAllFilterMilitaryStatus(FilterMilitaryRequest request)
		{
			var query = _militaryReadRepository.GetAll().Where(x => x.RemovedDate == null);
			if (request.IsDone.HasValue)
			{
				query=query.Where(x=>x.IsDone == request.IsDone);
			}
			var response = query.Select(x => new MilitaryResponse
			{
				IsDone =x.IsDone,
				AddedBy=x.AddedBy,
				CreatedDate=x.CreatedDate,
				Delay=x.Delay,
				DelayEndDate=x.DelayEndDate,
				EndDate=x.EndDate,
				Id=x.Id,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate=x.ModifiedDate,
				RemovedBy=x.RemovedBy,
				//Kimin bu onu da gormek istiyorum.
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<MilitaryResponse>>(false, "Military Information List IS EMPTY");
			}
			return new BaseResponse<List<MilitaryResponse>>(response, true, "Military Information LIST :");
		}

		public BaseResponse<List<MilitaryResponse>> GetAllMilitaryStatus()
		{
			var query= _militaryReadRepository.GetAll().Where(x=>x.RemovedDate == null);
			if(query is null)
			{
				return new BaseResponse<List<MilitaryResponse>>(false, "Military Information List is NULL");
			}
			List<MilitaryResponse> mapData = new List<MilitaryResponse>();
			foreach (var item in query)
			{
				MilitaryResponse response = new MilitaryResponse
				{
					Id=item.Id,
					AppUserId=item.AppUserId,
					IsDone=item.IsDone,
					Delay=item.Delay,
					DelayEndDate=item.DelayEndDate,
					EndDate=item.EndDate,
					AddedBy=item.AddedBy,
					ModifiedBy=item.ModifiedBy,
					RemovedBy=item.RemovedBy,
					IsStatus=item.IsStatus,
					CreatedDate=item.CreatedDate,
					ModifiedDate=item.ModifiedDate,
					RemovedDate=item.ModifiedDate,
				};
				mapData.Add(response);
			}
			return new BaseResponse<List<MilitaryResponse>>(mapData, true, "Military Information LIST:");
		}

		public async Task<BaseResponse<MilitaryResponse>> GetMilitaryStatusById(int id)
		{
			var checkData= await _militaryReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<MilitaryResponse>(false, "Military Information NOT FOUND");
			}
			MilitaryResponse mapData = new MilitaryResponse
			{
				Id=checkData.Id,
				AppUserId=checkData.AppUserId,
				IsStatus = checkData.IsStatus,
				IsDone = checkData.IsDone,
				Delay = checkData.Delay,
				DelayEndDate = checkData.DelayEndDate,
				EndDate = checkData.EndDate,
				AddedBy = checkData.AddedBy,
				CreatedDate = checkData.CreatedDate,
				RemovedDate = checkData.RemovedDate,
				ModifiedDate = checkData.ModifiedDate,
				RemovedBy = checkData.ModifiedBy,
				ModifiedBy = checkData.ModifiedBy
			};
			return new BaseResponse<MilitaryResponse>(mapData, true, "Military Information: ");
		}

		public BaseResponse<MilitaryResponse> GetMilitaryStatutsFilter(FilterMilitaryRequest request)
		{
			var query = _militaryReadRepository.GetAll().Where(x => x.RemovedDate == null);
			if (request.IsDone.HasValue)
			{
				query = query.Where(x => x.IsDone == request.IsDone);
			}
			var response = query.Select(x => new MilitaryResponse
			{
				IsDone = x.IsDone,
				AddedBy = x.AddedBy,
				CreatedDate = x.CreatedDate,
				Delay = x.Delay,
				DelayEndDate = x.DelayEndDate,
				EndDate = x.EndDate,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				RemovedBy = x.RemovedBy,
				AppUserId=x.AppUserId,
				//Kimin bu onu da gormek istiyorum.
			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<MilitaryResponse>(false, "Military Information NOT FOUND");
			}
			return new BaseResponse<MilitaryResponse>(response, true, "Military Information :");
		}

		public async Task<BaseResponse<bool>> UpdateMilitaryStatus(UpdateMilitaryRequest request)
		{
			var checkData = await _militaryReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Military Information NOT FOUND");
			}
			checkData.IsDone = request.IsDone;
			checkData.DelayEndDate= request.DelayEndDate;
			checkData.Delay= request.Delay;
			checkData.EndDate= request.EndDate;
			checkData.ModifiedBy= request.ModifiedBy;
			checkData.IsStatus=request.IsStatus;
			checkData.ModifiedDate = DateTime.UtcNow;
			var respone= _militaryWriteRepository.Update(checkData);
			var save = await _militaryWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Military Information Update Operation IS FAILED");
			}
			return new BaseResponse<bool>(true, "Military Information Update Operation IS  SUCCESS");
		}
	}
}
