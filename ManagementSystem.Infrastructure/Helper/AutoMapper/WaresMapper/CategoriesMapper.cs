using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Wares.Category;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.WaresMapper
{
	public class CategoriesMapper : Profile
	{
        public CategoriesMapper()
        {
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category,UpdateCategoryRequest>().ReverseMap();
            CreateMap<Category,CategoryResponse>().ReverseMap();
            CreateMap<List<Category>, List<CategoryResponse>>().ReverseMap();
        }
    }
}
