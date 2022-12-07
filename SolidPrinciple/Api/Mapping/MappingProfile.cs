using Api.DTOs;
using Api.Models;
using AutoMapper;

namespace Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieEditDto>().ReverseMap();

        }
    }
}
