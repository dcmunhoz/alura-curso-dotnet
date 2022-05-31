using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(sessao => sessao.HoraDeInicio, opts => opts
                    .MapFrom(sessao => sessao.HoraDeEncerramento.AddMinutes(sessao.Filme.Duracao * (-1))));
        }
    }
}
