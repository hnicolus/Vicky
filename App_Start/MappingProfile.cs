using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vicky.Dtos;
using Vicky.Models;

namespace Vicky.App_Start
{ 
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto,Movie>();

        }
    }
}