﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Domain to Dto
      Mapper.CreateMap<Customer, CustomerDto>();
      Mapper.CreateMap<Movie, MovieDto>();
      Mapper.CreateMap<MembershipType, MembershipTypeDto>();
      Mapper.CreateMap<Genre, GenreDto>();

      // Dto to domain
      Mapper.CreateMap<CustomerDto, Customer>()
        .ForMember(c => c.Id, opt => opt.Ignore());
      Mapper.CreateMap<MovieDto, Movie>()
        .ForMember(m => m.Id, opt => opt.Ignore());
      
    }
  }
}