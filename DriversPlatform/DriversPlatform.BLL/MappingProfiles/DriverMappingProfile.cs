using AutoMapper;
using DriversPlatform.BLL.DTOs;
using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.MappingProfiles
{
    public class DriverMappingProfile : Profile
    {
        public DriverMappingProfile()
        {
            CreateMap<Driver, DriverDTO>().ForMember(d => d.User, ex => ex.MapFrom(o => o.User))
                                                .ForMember(d => d.Id, ex => ex.MapFrom(o => o.Id))
                                                .ForMember(d => d.Instructor, ex => ex.MapFrom(o => o.Instructor))
                                                .ForMember(d => d.EnrollmentDate, ex => ex.MapFrom(o => (Convert.ToDateTime(o.EnrollmentDate))))
                                                .ForMember(d => d.Category, ex => ex.MapFrom(o => o.Category))
                                                .ForMember(d => d.QuizResults, ex => ex.MapFrom(o => o.QuizResults))
                                                .ForMember(d => d.HasQuizAccess, ex => ex.MapFrom(o => o.HasQuizAccess))
                                                .ReverseMap();
        }
    }
}
