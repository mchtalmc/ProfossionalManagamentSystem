using AutoMapper;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Wares.Product;
using MagamentSystem.Application.Managers.Wares;
using MagamentSystem.Application.Repository.WaresRepository.Products;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Managers.Wares
{
	public class ProductManager : IProductManager
	{
		private readonly IProductReadRepository _productReadRepository;
		private readonly IProductWriteRepository _productWriteRepository;
		private readonly IMapper _mapper;

		public ProductManager(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
			_mapper = mapper;
		}

		public async Task<BaseResponse<bool>> CreateProduct(CreateProductRequest request)
		{
			Product map = new Product
			{
				DealerId=request.DealerId,
				Name=request.Name,
				IsStatus=request.IsStatus,
				Brand=request.Brand,
				Price=request.Price,
				ProductionDate=request.ProductionDate,
				ExpirationDate=request.ExpirationDate,
				IsUsedProduct=request.IsUsedProduct,
				CategoryId=request.CategoryId,
				ProducerId=request.ProducerId,
				MarketPlaceId=request.MarketPlaceId,
				AddedBy=request.AddedBy,
				CreatedDate=DateTime.UtcNow,
				

			};
			var response= await _productWriteRepository.AddAsync(map);
			var save = await _productWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Product Creating Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Product Creating Operation SUCCESS");
		}

	

		public async Task<BaseResponse<bool>> DeleteProduct(RemoveProductRequest request)
		{
			var checkData = await _productReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Product Removed Operation FAILED");
			}
			checkData.RemovedDate=DateTime.UtcNow;
			checkData.RemovedBy = request.RemovedBy;
			var response = _productWriteRepository.Remove(checkData);
			var save = await _productWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Product Removed Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Product Removed Operation SUCCESS");

		}

		public BaseResponse<List<ProductResponse>> GetAllProduct()
		{
			var datas = _productReadRepository.GetAll().Where(x => x.RemovedDate == null);
			if(datas is null)
			{
				return new BaseResponse<List<ProductResponse>>(false, "Product List is EMPTY");
			}
			List<ProductResponse> map = new List<ProductResponse>();
			foreach (var data in datas)
			{
				ProductResponse mapTo = new ProductResponse
				{
					RemovedBy = data.RemovedBy,
					RemovedDate = data.RemovedDate,
					AddedBy = data.AddedBy,
					Brand = data.Brand,
					CategoryId = data.CategoryId,
					CreatedDate = data.CreatedDate,
					DealerId = data.DealerId,
					ExpirationDate=data.ExpirationDate,
					Id = data.Id,
					IsUsedProduct = data.IsUsedProduct,
					MarketPlaceId = data.MarketPlaceId,
					ModifiedBy = data.ModifiedBy,
					ModifiedDate = data.ModifiedDate,
					Name = data.Name,
					Price = data.Price,
					ProducerId = data.ProducerId,
					ProductionDate = data.ProductionDate
					
				};
				map.Add(mapTo);
			}
			return new BaseResponse<List<ProductResponse>>(map, true, "Product LIST");
		}

		public BaseResponse<List<ProductResponse>> GetAllProductFilter(FilterProductRequest request)
		{
			var query = _productReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Brand))
			{
				query=query.Where(x=>x.Brand.Contains(request.Brand));
			}
			if(request.Price.HasValue)
			{
				query=query.Where(x=> x.Price==request.Price);
			}
			if(request.IsUsedProduct.HasValue)
			{
				query=query.Where(x=>x.IsUsedProduct ==request.IsUsedProduct);
			}
			if(request.CategoryId.HasValue)
			{
				query=query.Where(x=>x.CategoryId==request.CategoryId);
			}
			if(request.ProducerId.HasValue)
			{
				query = query.Where(x => x.ProducerId==request.ProducerId);
			}
			if(request.DealerId.HasValue)
			{
				query=query.Where(x=> x.DealerId==request.DealerId);
			}
			if(request.MarketPlaceId.HasValue)
			{
				query=query.Where(x=>x.MarketPlaceId==request.MarketPlaceId);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new ProductResponse
			{
				RemovedDate = x.RemovedDate,
				MarketPlaceId = x.MarketPlaceId,
				AddedBy=x.AddedBy,
				Brand=x.Brand,
				CategoryId=x.CategoryId,
				CreatedDate=x.CreatedDate,
				DealerId=x.DealerId,
				ExpirationDate=x.ExpirationDate,
				Id=x.Id,
				IsUsedProduct=x.IsUsedProduct,
				ModifiedBy=x.ModifiedBy,
				ModifiedDate=x.ModifiedDate,
				Name=x.Name,
				Price=x.Price,
				ProducerId = x.ProducerId,
				ProductionDate=x.ProductionDate,
				RemovedBy= x.RemovedBy,
				
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<ProductResponse>>(false, "Product List is EMPTY");
			}
			return new BaseResponse<List<ProductResponse>>(response, true, "Product LIST");
		}

		public async Task<BaseResponse<ProductResponse>> GetProductById(int id)
		{
			var checkData = await _productReadRepository.GetSingleById(id);
			if(checkData is null) {
				return new BaseResponse<ProductResponse>(false, "Product NOT FOUND");
				}
			ProductResponse MAP = new ProductResponse
			{
				ProductionDate=checkData.ProductionDate,
				ProducerId=checkData.ProducerId,
				Price = checkData.Price,
				Name=checkData.Name,
				ModifiedDate = checkData.ModifiedDate,
				ModifiedBy = checkData.ModifiedBy,
				MarketPlaceId=checkData.MarketPlaceId,
				AddedBy = checkData.AddedBy,
				Brand = checkData.Brand,
				CategoryId=checkData.CategoryId,
				CreatedDate=checkData.CreatedDate,
				DealerId=checkData.DealerId,
				ExpirationDate=checkData.ExpirationDate,
				Id=checkData.Id,
				IsUsedProduct=checkData.IsUsedProduct,
				RemovedBy=checkData.RemovedBy,
				RemovedDate= checkData.RemovedDate,
				
			};
			return new BaseResponse<ProductResponse>(MAP, true, "Product LIST");
		}

		public BaseResponse<ProductResponse> GetProductFilter(FilterProductRequest request)
		{
			var query = _productReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Brand))
			{
				query = query.Where(x => x.Brand.Contains(request.Brand));
			}
			if (request.Price.HasValue)
			{
				query = query.Where(x => x.Price == request.Price);
			}
			if (request.IsUsedProduct.HasValue)
			{
				query = query.Where(x => x.IsUsedProduct == request.IsUsedProduct);
			}
			if (request.CategoryId.HasValue)
			{
				query = query.Where(x => x.CategoryId == request.CategoryId);
			}
			if (request.ProducerId.HasValue)
			{
				query = query.Where(x => x.ProducerId == request.ProducerId);
			}
			if (request.DealerId.HasValue)
			{
				query = query.Where(x => x.DealerId == request.DealerId);
			}
			if (request.MarketPlaceId.HasValue)
			{
				query = query.Where(x => x.MarketPlaceId == request.MarketPlaceId);
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new ProductResponse
			{
				RemovedDate = x.RemovedDate,
				MarketPlaceId = x.MarketPlaceId,
				AddedBy = x.AddedBy,
				Brand = x.Brand,
				CategoryId = x.CategoryId,
				CreatedDate = x.CreatedDate,
				DealerId = x.DealerId,
				ExpirationDate = x.ExpirationDate,
				Id = x.Id,
				IsUsedProduct = x.IsUsedProduct,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,
				Name = x.Name,
				Price = x.Price,
				ProducerId = x.ProducerId,
				ProductionDate = x.ProductionDate,
				RemovedBy = x.RemovedBy,

			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<ProductResponse>(false, "Product NOT FOUND");
			}
			return new BaseResponse<ProductResponse>(response, true, "Product");
		}

		public async Task<BaseResponse<bool>> UpdateProduct(UpdateProductRequest request)
		{
			var checkData = await _productReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Product Update Operation FAILED");
			}
			checkData.Name = request.Name;
			checkData.Price = request.Price;
			checkData.Brand = request.Brand;
			checkData.ExpirationDate= request.ExpirationDate;
			checkData.ProductionDate = request.ProductionDate;
			checkData.IsStatus= request.IsStatus;
			checkData.IsUsedProduct= request.IsUsedProduct;
			checkData.CategoryId= request.CategoryId;
			checkData.ProducerId= request.ProducerId;
			checkData.DealerId = request.DealerId;
			checkData.ModifiedBy=request.ModifiedBy;
			checkData.ModifiedDate = DateTime.UtcNow;

			var response= _productWriteRepository.Update(checkData);
			var save = await _productWriteRepository.Save();
			if(save < 0)
			{
				return new BaseResponse<bool>(false, "Product Update Opeation FAILED");
			}
			return new BaseResponse<bool>(true, "Product Update Operation SUCCESS");
		}
	}
}
