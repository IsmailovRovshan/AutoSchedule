﻿using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Entities.Users;

namespace Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, ClientDtoForCreate>().ReverseMap();
            CreateMap<Client, ClientDtoForUpdate>().ReverseMap();

            CreateMap<Teacher,TeacherDto>().ReverseMap();
            CreateMap<Teacher,TeacherDtoForCreate>().ReverseMap();
            CreateMap<Teacher,TeacherDtoForUpdate>().ReverseMap();

            CreateMap<Manager, ManagerDto>().ReverseMap();
            CreateMap<Manager, ManagerDtoForCreate>().ReverseMap();
            CreateMap<Manager, ManagerDtoForUpdate>().ReverseMap();

            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Lesson, LessonDtoForCreate>().ReverseMap();
            CreateMap<Lesson, LessonDtoForUpdate>().ReverseMap();
            CreateMap<Lesson, LessonDtoForAutoCreate>().ReverseMap();

        }
    }
}
