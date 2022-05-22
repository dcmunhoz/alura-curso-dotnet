using AutoMapper;
using FilmesApi.Models;
using FilmesApi.Data.DTOs;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {

        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>();
            CreateMap<UpdateCinemaDTO, Cinema>();
        }

    }
}
