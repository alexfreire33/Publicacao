using AI.Cadastro.API.AutoMapper;
using Emergencia.Aplication.Mensagens;
using Emergencia.Aplication.Services;
using Emergencia.Domain.Interfaces;
using Emergencia.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.CrossCutting.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PbiContext>(options =>
                  options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IClienteMessage, PublishPagamento>();

        services.AddAutoMapper(typeof(AutoMapperSetup));

        return services;
    }
}
