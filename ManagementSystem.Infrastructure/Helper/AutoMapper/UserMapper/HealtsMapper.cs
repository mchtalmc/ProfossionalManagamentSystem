using AutoMapper;
using MagamentSystem.Application.DataTransferObject.User.Healt;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.UserMapper
{
	public class HealtsMapper : Profile
	{
        public HealtsMapper()
        {
            CreateMap<HealthStatus, CreateHealtyRequest>().ReverseMap();
            CreateMap<HealthStatus,UpdateHealtyRequest>().ReverseMap();
            CreateMap<HealthStatus,HealtResponse>().ReverseMap();
            CreateMap<List<HealtResponse>, List<HealthStatus>>().ReverseMap();
        }
    }
}
