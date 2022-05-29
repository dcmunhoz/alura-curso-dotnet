using AutoMapper;
using FilmesApi.Models;
using FilmesApi.Data.DTOs;

namespace FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {

        public GerenteProfile()
        {
            CreateMap<AdicionarGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>();
            CreateMap<EditarGerenteDTO, Gerente>();
        }

    }
}
