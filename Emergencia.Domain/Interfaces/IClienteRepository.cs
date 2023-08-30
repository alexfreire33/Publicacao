using Emergencia.Domain.Entities;
using Emergencia.Infrastructure.Models;

namespace Emergencia.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAsync();
        Task<bool> CreateAsync(Inscricao inscricao);
        Task<bool> EfetuaPagamento(Pagamento pagamento);
        Task<bool> UpdateInscricao(Inscricao inscricao);
        Task<Evento> GetEventoAsync(Guid cd_evento);


    }
}
