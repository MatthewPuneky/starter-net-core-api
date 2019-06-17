using AutoMapper;
using StarterProject.Api.Common.Constants;
using StarterProject.Api.Data.Entities;
using StarterProject.Api.Dtos;

namespace StarterProject.Api.Features.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<GetUserDto, User>().ReverseMap();

            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.Role, opts => opts.Ignore())
                .ForMember(dest => dest.PasswordSalt, opts => opts.Ignore())
                .ForMember(dest => dest.PasswordHash, opts => opts.Ignore());
        }
    }
}
