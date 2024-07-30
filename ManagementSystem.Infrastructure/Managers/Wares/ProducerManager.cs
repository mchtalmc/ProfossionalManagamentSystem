using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Wares.Producer;
using MagamentSystem.Application.Managers.Wares;
using MagamentSystem.Application.Repository.WaresRepository.Producers;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Managers.Wares
{
	public class ProducerManager : IProducerManager
	{
		private readonly IProducerReadRepository _producerReadRepository;
		private readonly IProducerWriteRepository _producerWriteRepository;
		

		public ProducerManager(IProducerReadRepository producerReadRepository, IProducerWriteRepository producerWriteRepository)
		{
			_producerReadRepository = producerReadRepository;
			_producerWriteRepository = producerWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateProducer(CreateProducerRequest request)
		{
			Producer map = new Producer
			{
				CreatedDate = DateTime.UtcNow,
				IsStatus = request.IsStatus,
				AddedBy = request.AddedBy,
				Email = request.Email,
				Location = request.Location,
				PhoneNumber = request.PhoneNumber,
				Name = request.Name,

			};
			var response= await _producerWriteRepository.AddAsync(map);
			var save = await _producerWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Producer Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Producer Craeting Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteProducer(RemoveProducerRequest request)
		{
			var checkData = await _producerReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Producer NOT FOUND");
			}
			checkData.RemovedBy = request.RemovedBy;
			checkData.RemovedDate = DateTime.UtcNow;
			var remove = _producerWriteRepository.Remove(checkData);
			var save = await _producerWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Producer Remove Operation Failed");
			}
			return new BaseResponse<bool>(true, "Producer Remove Operation Success");
		}

		public BaseResponse<List<ProducerResponse>> GetAllProducer()
		{
			var datas = _producerReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			if(datas is null)
			{
				return new BaseResponse<List<ProducerResponse>>(false, "Producer List is EMPTY");
			}
			List<ProducerResponse> mapTO= new List<ProducerResponse>();
			foreach (var data in datas)
			{
				ProducerResponse map = new ProducerResponse
				{
					Name = data.Name,
					AddedBy = data.AddedBy,
					CreatedDate = data.CreatedDate,
					Email = data.Email,
					Id = data.Id,
					Location = data.Location,
					ModifiedBy = data.ModifiedBy,
					ModifiedDate = data.ModifiedDate,
					PhoneNumber = data.PhoneNumber,
					RemovedBy = data.RemovedBy,
					RemovedDate = data.RemovedDate,
					
				};
				mapTO.Add(map);
			}
			return new BaseResponse<List<ProducerResponse>>(mapTO, true, "Producer LIST");
		}

		public BaseResponse<List<ProducerResponse>> GetAllProducerFilter(FilterProducerRequest request)
		{
			var query = _producerReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Location))
			{
				query=query.Where(x=>x.Location.Contains(request.Location));
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new ProducerResponse
			{
				RemovedDate = x.RemovedDate,
				AddedBy=x.AddedBy,
				CreatedDate = x.CreatedDate,
				Email = x.Email,
				Id = x.Id,
				Location = x.Location,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Name = x.Name,
				PhoneNumber = x.PhoneNumber,
				RemovedBy = x.RemovedBy,
				
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<ProducerResponse>>(false, "Producer List is EMPTY");
			}
			return new BaseResponse<List<ProducerResponse>>(response, true, "Producer LIST");

		}

		public async Task<BaseResponse<ProducerResponse>> GetProducerById(int id)
		{
			var checkData = await _producerReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<ProducerResponse>(false, "Producer NOT FOUND");
			}
			ProducerResponse map = new ProducerResponse
			{
				RemovedDate= checkData.RemovedDate,
				RemovedBy=checkData.RemovedBy,
				CreatedDate= checkData.CreatedDate,
				PhoneNumber= checkData.PhoneNumber,
				ModifiedDate= checkData.ModifiedDate,
				ModifiedBy = checkData.ModifiedBy,
				AddedBy = checkData.AddedBy,
				Email= checkData.Email,
				Id= checkData.Id,
				Location= checkData.Location,
				Name = checkData.Name,
				
			};
			return new BaseResponse<ProducerResponse>(map, true, "Producer ;");
		}

		public BaseResponse<ProducerResponse> GetProducerFilter(FilterProducerRequest request)
		{
			var query = _producerReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Location))
			{
				query = query.Where(x => x.Location.Contains(request.Location));
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new ProducerResponse
			{
				RemovedDate = x.RemovedDate,
				AddedBy = x.AddedBy,
				CreatedDate = x.CreatedDate,
				Email = x.Email,
				Id = x.Id,
				Location = x.Location,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Name = x.Name,
				PhoneNumber = x.PhoneNumber,
				RemovedBy = x.RemovedBy,

			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<ProducerResponse>(false, "Producer NOT FOUND");
			}
			return new BaseResponse<ProducerResponse>(true, "Producer :");
		}

		public async Task<BaseResponse<bool>> UpdateProducer(UpdateProducerRequest request)
		{
			var checkData = await _producerReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Producer NOT FOUND");
			}
			checkData.Location= request.Location;
			checkData.ModifiedDate = DateTime.UtcNow;
			checkData.Email= request.Email;
			checkData.PhoneNumber = request.PhoneNumber;
			checkData.Name=request.Name;
			checkData.ModifiedBy= request.ModifiedBy;
			checkData.IsStatus=request.IsStatus;
			var update= _producerWriteRepository.Update(checkData);
			var save = await _producerWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Producer Update Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Producer Update Operation SUCCESS");
		}
	}
}
