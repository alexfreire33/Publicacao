using DP.Core;
using Emergencia.Domain.Entities;

namespace Emergencia.Infrastructure.Models;

public  class Cliente : Entity
{
    public string? NmCliente { get; set; }

    public string? NrCpf { get;  set; }

    public string? Email { get; set; }

    public ICollection<Pagamento>? Pagamentos { get; set; }

    public ICollection<Inscricao>? Inscricoes { get; set; }

}
