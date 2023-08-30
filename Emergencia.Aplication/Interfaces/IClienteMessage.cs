using Emergencia.Aplication.DTOs;
using Emergencia.Domain.Entities;
using Emergencia.Infrastructure.Models;

namespace Emergencia.Domain.Interfaces;

public interface IClienteMessage
{
    Task PublicaPagamento(InscricaoDto inscricao);


}
