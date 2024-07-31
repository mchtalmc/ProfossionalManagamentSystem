using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Wares.Category;
using MagamentSystem.Application.Managers.Wares;
using MagamentSystem.Application.Repository.WaresRepository.Categoryies;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Managers.Wares
{
	public class CategoryManager : ICategoryManager
	{
		private readonly ICategoryReadRepository _categoryReadRepository;
		private readonly ICategoryWriteRepository _categoryWriteRepository;
		

		public CategoryManager(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
		{
			_categoryReadRepository = categoryReadRepository;
			_categoryWriteRepository = categoryWriteRepository;
			
		}

		public async Task<BaseResponse<bool>> CreateCategory(CreateCategoryRequest request)
		{

			Category map = new Category
			{
				Name = request.Name,
				AddedBy = request.AddedBy,
				CreatedDate=DateTime.UtcNow,
			};
			var response= await _categoryWriteRepository.AddAsync(map);
			var SAVE = await _categoryWriteRepository.Save();
			if(SAVE < 0)
			{
				return new BaseResponse<bool>(false, "Category Create Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Category Create Operation SUCCESS");
		}

		public async Task<BaseResponse<bool>> DeleteCategory(RemoveCategoryRequest request)
		{
			var checkData = await _categoryReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Category Remove Operation FAILED");
			}
			checkData.RemovedBy=request.Id;
			checkData.RemovedDate = DateTime.UtcNow;
			var response = _categoryWriteRepository.Update(checkData);
			var save = await _categoryWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, " Category Remove Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Category Remove Operation SUCCESS");
		}

		public BaseResponse<List<CategoryResponse>> GetAllCategory()
		{
			var datas = _categoryReadRepository.GetAll().Where(x => x.RemovedDate == null).ToList();
			if(datas is null)
			{
				return new BaseResponse<List<CategoryResponse>>(false, "Category List is EMPTY");
			}
			List<CategoryResponse> list = new List<CategoryResponse>();
			foreach (var data in datas)
			{
				CategoryResponse map = new CategoryResponse
				{
					AddedBy = data.AddedBy,
					CreatedDate = data.CreatedDate,
					Id = data.Id,
					ModifiedBy=data.ModifiedBy,
					ModifiedDate = data.ModifiedDate,
					Name = data.Name,
					RemovedBy=data.Id,
					RemovedDate = data.RemovedDate,
					
				};
				list.Add(map);
			}
			return new BaseResponse<List<CategoryResponse>>(list, true, "Category LIST:");
		}

		public BaseResponse<List<CategoryResponse>> GetAllCategoryFilter(FilterCategoryRequest request)
		{
			var query = _categoryReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Name))
			{
				query = query.Where(x => x.Name.Contains(request.Name));
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new CategoryResponse
			{
				Name = x.Name,
				RemovedDate = x.RemovedDate,
				RemovedBy = x.RemovedBy,
				AddedBy = x.AddedBy,
				CreatedDate = x.CreatedDate,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate=x.ModifiedDate,
				
			}).ToList();
			if(response is null)
			{
				return new BaseResponse<List<CategoryResponse>>(false, "Category List is EMPTY");
			}
			return new BaseResponse<List<CategoryResponse>>(response, true, "Category LIST");
		}

		public async Task<BaseResponse<CategoryResponse>> GetCategoryById(int id)
		{
			var checkData = await _categoryReadRepository.GetSingleById(id);
			if(checkData is null)
			{
				return new BaseResponse<CategoryResponse>(false, "Category NOT FOUND");
			}
			CategoryResponse map = new CategoryResponse
			{
				ModifiedDate=checkData.ModifiedDate,
				ModifiedBy=checkData.ModifiedBy,
				AddedBy=checkData.AddedBy,
				CreatedDate=checkData.CreatedDate,
				Id=checkData.Id,
				Name=checkData.Name,
				RemovedBy=checkData.RemovedBy,
				RemovedDate = checkData.RemovedDate,
				
			};
			return new BaseResponse<CategoryResponse>(map, true, "Category :");
		}

		public BaseResponse<CategoryResponse> GetCategoryFilter(FilterCategoryRequest request)
		{
			var query = _categoryReadRepository.GetAll();
			if (!string.IsNullOrEmpty(request.Name))
			{
				query = query.Where(x => x.Name.Contains(request.Name));
			}
			var response = query.Where(x => x.RemovedDate == null).Select(x => new CategoryResponse
			{
				Name = x.Name,
				RemovedDate = x.RemovedDate,
				RemovedBy = x.RemovedBy,
				AddedBy = x.AddedBy,
				CreatedDate = x.CreatedDate,
				Id = x.Id,
				ModifiedBy = x.ModifiedBy,
				ModifiedDate = x.ModifiedDate,

			}).FirstOrDefault();
			if(response is null)
			{
				return new BaseResponse<CategoryResponse>(false, "Category NOT FOUND");
			}
			return new BaseResponse<CategoryResponse>(response, true, "Category :");
		}

		public async Task<BaseResponse<bool>> UpdateCategory(UpdateCategoryRequest request)
		{
			var checkData = await _categoryReadRepository.GetSingleById(request.Id);
			if(checkData is null)
			{
				return new BaseResponse<bool>(false, "Category NOT FOUND");
			}
			
				checkData.Name=request.Name;
			checkData.ModifiedDate=request.ModifiedDate;
			checkData.ModifiedDate = DateTime.UtcNow;
			checkData.IsStatus= request.IsStatus;

			var response = _categoryWriteRepository.Update(checkData);
			var save = await _categoryWriteRepository.Save();
			if (save < 0)
			{
				return new BaseResponse<bool>(false, "Category Update Operation FAILED");
			}
			return new BaseResponse<bool>(true, "Category Update Operation SUCCESS");
		}
	}
}
