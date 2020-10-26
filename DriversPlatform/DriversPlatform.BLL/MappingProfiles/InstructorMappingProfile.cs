using AutoMapper;
using DriversPlatform.BLL.DTOs;
using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriversPlatform.BLL.MappingProfiles
{
    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<Instructor, InstructorDTO>().ForMember(i => i.User, ex => ex.MapFrom(o => o.User))
                                                  .ForMember(i => i.Id, ex => ex.MapFrom(o => o.Id))
                                                  .ForMember(i => i.Salary, ex => ex.MapFrom(o => o.Salary))
                                                  .ForMember(i => i.Clients, ex => ex.MapFrom(o => o.Clients))
                                                  .ForMember(i => i.HireDate, ex => ex.MapFrom(o => (Convert.ToDateTime(o.HireDate))))
                                                  .ForMember(i => i.Categories, ex => ex.MapFrom(o => o.InstructorCategory.Select(ic => ic.Category).ToList()))
                                                  .ReverseMap();
        }
    }
}
