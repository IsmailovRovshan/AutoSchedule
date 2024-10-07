using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Entities.Users;

namespace Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Client,ClientDto>().ReverseMap();
            CreateMap<Teacher,TeacherDto>().ReverseMap();
        }
    }
}
