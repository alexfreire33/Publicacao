
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DP.MessageBus;
using AutoMapper;
using Emergencia.Domain.Interfaces;
using Emergencia.Domain.Entities;
using Emergencia.Aplication.DTOs;

namespace Emergencia.Aplication.Mensagens;

public class PublishPagamento : BackgroundService, IClienteMessage
{
    private readonly IMessageBus _bus;
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;

    public PublishPagamento(
                        IServiceProvider serviceProvider,
                        IMessageBus bus,
                        IMapper mapper
                        )
    {
        _serviceProvider = serviceProvider;
        _bus = bus;
        _mapper = mapper;

    }

    /*esse metodo é chamado quando a aplicação é iniciada*/
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        SetSubscribers();
        return Task.CompletedTask;
    }

    /*cria o topico EfetuaPagamento, isso é criado no rabbit uma vez */
    private void SetSubscribers()
    {
        _bus.SubscribeAsync<Pagamento>("EfetuaPagamento", async request =>
           await EfetuaPagamento(request));//toda vez que o objeto Pagamento for preenchido a função EfetuaPagamento vai ser chamado pelo evento autoamticamente
    }

    private async Task EfetuaPagamento(Pagamento request)
    {
        Console.WriteLine("inicio das regras da publicacao...");

        await Task.Delay(5000);//só para demonstrar a vantagem de liberar o cliente e processar no futuro

        using (var scope = _serviceProvider.CreateScope())
        {
            var clienteRepository = scope.ServiceProvider.GetRequiredService<IClienteRepository>();//pega a instancia do repositorio somente uma vez nesse contexto
            var retornoPagamento = await clienteRepository.EfetuaPagamento(request);

            if (retornoPagamento)
            {
                /*Se o pagamento for efetuado ele atualiza o status da inscrição*/
                var inscricaoObj = new Inscricao() { Id = request.Id, Status = "Pagamento aprovado" };
                await clienteRepository.UpdateInscricao(inscricaoObj);
                Console.WriteLine("fim das regras da publicacao...");

                return;
            }
            else
            {
                throw new ArgumentException(nameof(request));
            }
        }
    }

    public async Task PublicaPagamento(InscricaoDto inscricao)
    {
        using (var scope = _serviceProvider.CreateScope()) //usa o scope para somente existir aqui, quando ele finalizar esse trecho ele libera os serviços
        {
            var pagamentoEntity = _mapper.Map<Pagamento>(inscricao);//mapeia para inscrição o dto

            await _bus.PublishAsync(pagamentoEntity);

        }
    }
}