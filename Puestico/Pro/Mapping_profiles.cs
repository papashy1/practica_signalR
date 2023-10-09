using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Entidades;

namespace Puestico.Profiles
{
    public class Mapping_profiles : Profile
    {
            public Mapping_profiles()
    {
        CreateMap<Usuario, Usuario_dto>().ReverseMap();
        CreateMap<Persona, Usuario_dto>().ReverseMap();
    }
    }
}