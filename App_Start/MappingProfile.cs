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
            //Domain to Dto
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Series, SeriesDto>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //DTO to Domain

            //Mapper.CreateMap<CategoryDto, Category>();
            //Mapper.CreateMap<GenreDto, Genre>();
            //Mapper.CreateMap<SeriesDto, Series>();
            Mapper.CreateMap<MovieDto,Movie>();



        }
    }
}