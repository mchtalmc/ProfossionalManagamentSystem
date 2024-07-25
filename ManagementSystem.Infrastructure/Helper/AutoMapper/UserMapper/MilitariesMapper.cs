using AutoMapper;
using MagamentSystem.Application.DataTransferObject.User.Military;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.UserMapper
{
	public class MilitariesMapper : Profile
	{
        public MilitariesMapper()
        {
            CreateMap<MilitaryStatus, CreateMilitaryRequest>().ReverseMap();
            CreateMap<MilitaryStatus,UpdateMilitaryRequest>().ReverseMap();
            CreateMap<MilitaryStatus,MilitaryResponse>().ReverseMap();
            CreateMap<List<MilitaryStatus>, List<MilitaryResponse>>().ReverseMap();
        }
    }
}
