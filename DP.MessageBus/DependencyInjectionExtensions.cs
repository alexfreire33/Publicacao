using Microsoft.Extensions.DependencyInjection;

namespace DP.MessageBus;

public static class StartupExtension
{
    public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
    {

        services.AddSingleton<IMessageBus>(new MessageBus(connection));

        return services;
    }

}
