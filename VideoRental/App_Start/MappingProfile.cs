using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Dtos;
using VideoRental.Models;

namespace VideoRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(m => m.MovieId, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(x => x.DateAdded,opt => opt.ResolveUsing(x => x.DataAdded = DateTime.UtcNow));

            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}