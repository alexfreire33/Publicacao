using AutoMapper;
using Emergencia.Aplication.DTOs;
using Emergencia.Domain.Entities;
using Emergencia.Infrastructure.Models;

namespace AI.Cadastro.API.AutoMapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, InscricaoDto>().ReverseMap();
            CreateMap<Inscricao, InscricaoDto>().ReverseMap();
            CreateMap<Pagamento, InscricaoDto>().ReverseMap();

        }
    }
}