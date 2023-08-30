using AutoMapper;
using Emergencia.Aplication.DTOs;
using Emergencia.Domain.Entities;
using Emergencia.Domain.Interfaces;

namespace Emergencia.Aplication.Services;

public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly IClienteRepository _clienteRepository;
    private readonly IClienteMessage _clienteMessage;

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository, IClienteMessage clienteMessage)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
        _clienteMessage = clienteMessage;
    }

    public async Task<IEnumerable<InscricaoDto>> GetAsync()
    {

        var retorno = await _clienteRepository.GetAsync();
        var cliente = _mapper.Map<IEnumerable<InscricaoDto>>(retorno);
        return cliente;
    }

    public async Task Inscricao(InscricaoDto inscricao)
    {
        var inscricaoEntidade = _mapper.Map<Inscricao>(inscricao);

        var retornoEvento = await _clienteRepository.GetEventoAsync(inscricao.CdEvento);

        if (inscricao.vlPagamento < retornoEvento.vlEvento) //isso é só um exemplo, no caso real não precisaria fazer a comparação e sim já pegar do banco
        {
            throw new ArgumentException(nameof(retornoEvento));

        }
        else
        {
            var retorno  = await _clienteRepository.CreateAsync(inscricaoEntidade); //Persiste na base a inscrição com status aguardando pagamento
            Console.WriteLine("liberado para o cliente");

            if (retorno)
            {
                Console.WriteLine("espera para publicar o evento");
                await _clienteMessage.PublicaPagamento(inscricao); //publica na fila para processar o pagamento
            }
            else
            {
                throw new ArgumentException(nameof(retorno));

            }

        }

    }


}
