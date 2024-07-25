using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Wares.Producer;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.WaresMapper
{
	public class ProducersMapper : Profile
	{
        public ProducersMapper()
        {

            CreateMap<Producer, CreateProducerRequest>().ReverseMap();
            CreateMap<Producer, UpdateProducerRequest>().ReverseMap();
            CreateMap<Producer, ProducerResponse>().ReverseMap();
            CreateMap<List<ProducerResponse>, List<Producer>>().ReverseMap();

        }
    }
}
