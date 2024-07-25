using AutoMapper;
using MagamentSystem.Application.DataTransferObject.User.AppUser;
using ManagamentSystem.Core.Entities;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.UserMapper
{
	public class AppUserMapper : Profile
	{
        public AppUserMapper()
        {
            CreateMap<AppUser, CreateAppUserRequest>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserRequest>().ReverseMap();
            CreateMap<AppUser, AppUserResponse>().ReverseMap();
            CreateMap<List<AppUser>, List<AppUserResponse>>().ReverseMap();
        }
    }
}
