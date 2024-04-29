using AutoMapper;
using CleanArchitecture.Application.Dtos.GenderDtos;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Profiles
{
    public class DomainToDtosProfile : Profile
    {
        public DomainToDtosProfile()
        {
            CreateMap<Gender,CreateGenderDto>().ReverseMap();
            CreateMap<Gender, GenderDto>();
        }
    }
}
