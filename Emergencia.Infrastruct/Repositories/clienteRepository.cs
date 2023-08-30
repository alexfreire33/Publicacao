using Emergencia.Domain.Entities;
using Emergencia.Infrastructure.Context;
using Emergencia.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Emergencia.Domain.Interfaces
{

    public class ClienteRepository : IClienteRepository
    {
        private PbiContext _pibiContext;

        public ClienteRepository(PbiContext pibiContext)
        {
            _pibiContext = pibiContext;
        }

        public async Task<bool> CreateAsync(Inscricao inscricao)
        {

            try
            {
                _pibiContext.Set<Inscricao>().Add(inscricao);
                await _pibiContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("erro" + ex.Message);
                return false;
            }
          
        }

        public async Task<bool> EfetuaPagamento(Pagamento pagamento)
        {
            try
            {
                _pibiContext.Set<Pagamento>().Add(pagamento);
                await _pibiContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("erro" + ex.Message);
                return false;
            }

        }

        public async Task<IEnumerable<Cliente>> GetAsync()
        {

            var query = from cliente in _pibiContext.Clientes
                        select cliente;

            return await query.ToListAsync();

        }

        public async Task<Evento> GetEventoAsync(Guid cd_evento)
        {
            return await _pibiContext.Set<Evento>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == cd_evento);
        }

        public async Task<bool> UpdateInscricao(Inscricao inscricao)
        {
            try
            {
                var insc = _pibiContext.Insricoes.First(a => a.Id == inscricao.Id);
                insc.Status= inscricao.Status;
                await _pibiContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("erro" + ex.Message);

                return false;
            }
        }
    }


}

