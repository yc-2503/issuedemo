using AutoMapper;
using PESC.Domain.AggregatesModel.SCRM.RoleAggregate;
using PESC.Domain.AggregatesModel.SCRM.UserAggregate;
using PESC.Web.Application.ViewModels;

namespace PESC.Web.Application.Mappers;

public class ScrmAutoMapperProfile:Profile
{
    public ScrmAutoMapperProfile() 
    {
        CreateMap<User, UserDto>().ForMember(dest=>dest.Password,opt=>opt.Ignore());
        CreateMap<UserDto, User>();
        CreateMap<UserRole,UserRoleDto>().ReverseMap();
    }
}
