using Emergencia.Infrastructure.Models;

namespace Emergencia.Domain.Entities;

public class Inscricao : Entity
{

    public string? nrChave { get; set; }
    public string? Status { get; set; }
    public DateTime dtInsricao { get; set; }
    public Guid CdCliente { get; set; }

    public Guid CdEvento { get; set; }

    public Cliente? Cliente { get; set; }

    public Evento Evento { get; set; }


}
