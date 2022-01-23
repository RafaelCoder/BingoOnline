using AutoMapper;
using BingOnline.Persistencia.Modelo;

namespace BingOnline.Dtos.Perfil
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            //Usuario
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();

            //Partida
            CreateMap<CreatePartidaDto, Partida>();
            CreateMap<Partida, PartidaDto>();
            //CreateMap<UpdatePartidaDto, Partida>();

            //Participante
            CreateMap<Participante, ParticipanteDto>();

            CreateMap<Cartela, CartelaDto>();

            CreateMap<Numero, NumeroDto>();
        }
    }
}
