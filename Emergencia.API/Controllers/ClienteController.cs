using Emergencia.Aplication.DTOs;
using Emergencia.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text.Json.Serialization.Metadata;

namespace Emergencia.API.Controllers
{

    [Route("api/v1/inscricao")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;


        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;

        }

        [HttpPost(Name = "Inscricao")]
        public async Task<ActionResult> Inscricao(InscricaoDto inscricaoDto)
        {
            await _clienteService.Inscricao(inscricaoDto);

            return new CreatedAtRouteResult("Post", new { id = inscricaoDto.Id, inscricaoDto });

        }

    }
}