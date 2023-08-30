using Emergencia.Domain.Entities;

namespace Emergencia.Aplication.DTOs
{
    public class InscricaoDto : Entity
    {
        public Guid CdCliente { get; set; }
        public Guid CdEvento { get; set; }
        public decimal? vlPagamento { get; set; }
        public string? nrCartao { get; set; }


    }
}
