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
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                    .MapFrom(gerente => gerente.Cinemas.Select( c => new
                    {
                        c.Id,
                        c.Nome,
                        c.Endereco,
                        c.EnderecoId
                    } )));

            CreateMap<EditarGerenteDTO, Gerente>();
        }

    }
}
