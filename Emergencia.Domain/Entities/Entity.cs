using DP.Core;

namespace Emergencia.Domain.Entities
{
    public abstract class Entity : IntegrationEvent
    {
        public Guid Id { get;  set; } = Guid.NewGuid(); // Gera um novo GUID

    }
}
