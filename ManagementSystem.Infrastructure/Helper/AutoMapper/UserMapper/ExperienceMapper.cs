using AutoMapper;
using MagamentSystem.Application.DataTransferObject.User.Experience;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.UserMapper
{
	public class ExperienceMapper : Profile
	{
        public ExperienceMapper()
        {
            CreateMap<Experience,CreateExperienceRequest>().ReverseMap();
            CreateMap<Experience,UpdateExperienceRequest>().ReverseMap();
            CreateMap<Experience,ExperienceResponse>().ReverseMap();
            CreateMap<List<ExperienceResponse>, List<Experience>>().ReverseMap();
        }
    }
}
