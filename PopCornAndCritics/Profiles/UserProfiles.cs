using AutoMapper;
using PopCornAndCritics.Models;
using PopCornAndCritics.Models.DTOs;

namespace PopCornAndCritics.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<UpdateDTO, User>();
            CreateMap<User, UpdateDTO>();
            CreateMap<User, ReadUserDTO>();
        }
    }
}
