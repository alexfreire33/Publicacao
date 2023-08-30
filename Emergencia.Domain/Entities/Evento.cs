using Emergencia.Domain.Entities;

namespace Emergencia.Infrastructure.Models;

public class Evento : Entity
{
    
    public bool flAtivo { get; private set; }

    public decimal? vlEvento { get; set; }

    public string? nmEvento { get; set; }

    public DateTime? dtEvento { get; private set; }

    public ICollection<Inscricao>? Inscricoes { get; set; }
}
