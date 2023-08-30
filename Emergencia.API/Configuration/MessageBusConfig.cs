using DP.MessageBus;
using Emergencia.Aplication.Mensagens;
using Emergencia.Aplication.Services;
using System.Xml.Linq;

namespace Emergencia.API.Configuration;

public static class MessageBusConfig
{
    public static string AddMessageBusConfiguration(this IServiceCollection services,
             IConfiguration configuration)
    {

        services.AddMessageBus(configuration?.GetSection("MessageQueueConnection")?["MessageBus"])
               .AddHostedService<PublishPagamento>();

        return configuration?.GetSection("MessageQueueConnection")?["MessageBus"];
    }
}
