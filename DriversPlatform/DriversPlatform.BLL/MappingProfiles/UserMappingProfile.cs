using AutoMapper;
using DriversPlatform.BLL.DTOs;
using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDTO, User>().ForMember(u => u.UserName, ex => ex.MapFrom(o => o.Email))
                                                .ForMember(u => u.FirstName, ex => ex.MapFrom(o => o.FirstName))
                                                .ForMember(u => u.LastName, ex => ex.MapFrom(o => o.LastName))
                                                .ForMember(u => u.Birthday, ex => ex.MapFrom(o => (Convert.ToDateTime(o.Birthday))))
                                                .ForMember(u => u.Gender, ex => ex.MapFrom(o => o.Gender))
                                                .ForMember(u => u.Address, ex => ex.MapFrom(o => o.Address))
                                                .ForMember(u => u.PhoneNumber, ex => ex.MapFrom(o => o.PhoneNumber))
                                                .ForMember(u => u.Email, ex => ex.MapFrom(o => o.Email))
                                                .ForMember(u => u.PasswordHash, ex => ex.MapFrom(o => o.Password))
                                                .ReverseMap();

        }

    }
}
