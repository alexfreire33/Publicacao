using Catalogo.CrossCutting.IoC;
using Emergencia.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddInfrastructureAPI(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMessageBusConfiguration(builder.Configuration);//aqui configura o messagebus junto a conexão 

///aqui é para analisar performance, é uma lib bem simples e funcional, para acessar o resultado vai para: 
///https://localhost:SUA PORTA/profiler/results-index
builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler";
    options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
}).AddEntityFramework();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMiniProfiler();//para testar a performance da aplicação em dev
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
