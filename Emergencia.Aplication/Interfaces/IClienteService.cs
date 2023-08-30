using Emergencia.Aplication.DTOs;
using Emergencia.Infrastructure.Models;

namespace Emergencia.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<InscricaoDto>> GetAsync();
        Task Inscricao(InscricaoDto cliente);


    }
}
