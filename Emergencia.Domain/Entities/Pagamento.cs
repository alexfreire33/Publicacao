using DP.Core;
using Emergencia.Infrastructure.Models;

namespace Emergencia.Domain.Entities;

public class Pagamento : Entity
{
    public decimal? vlPagamento { get; set; }

    public int? QtdParcelas { get; set; }

    public Guid CdCliente { get; set; }

    public Cliente? Cliente { get; set; }

}
