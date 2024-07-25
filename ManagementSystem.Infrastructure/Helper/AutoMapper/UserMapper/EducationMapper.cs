using AutoMapper;
using MagamentSystem.Application.DataTransferObject.User.Education;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.UserMapper
{
	public class EducationMapper : Profile
	{
        public EducationMapper()
        {
            CreateMap<EducationStatus, CreateEducationRequest>().ReverseMap();
            CreateMap<EducationStatus, UpdateEducationRequest>().ReverseMap();
            CreateMap<EducationStatus, EducationResponse>().ReverseMap();
            CreateMap<List<EducationResponse>,List<EducationStatus>>().ReverseMap();
        }
    }
}
