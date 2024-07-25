using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Wares.Producer;
using MagamentSystem.Application.DataTransferObject.Wares.Product;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.WaresMapper
{
	public class ProductsMapper  : Profile
	{
        public ProductsMapper()
        {
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<ProductResponse, Product>().ReverseMap();
            CreateMap<List<ProductResponse>, List<Product>>().ReverseMap();
           

        }
    }
}
