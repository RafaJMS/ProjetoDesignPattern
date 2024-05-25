using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Connections;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Logging;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

string primaryConnectionString = builder.Configuration.GetConnectionString("ConexaoDBSQL");
string replicaConnectionString = builder.Configuration.GetConnectionString("ConexaoReplicaSQL");

var strategies = new List<IDbConnectionStrategy>
{
    new PrimaryDbConnectionStrategy(primaryConnectionString),
    new ReplicaDbConnectionStrategy(replicaConnectionString)
};

var dbConnectionManager = new DbConnectionManager(strategies);
string activeConnectionString = dbConnectionManager.GetActiveConnectionString();

builder.Services.AddDbContext<ContextSQL>(options =>
    options.UseSqlServer(activeConnectionString));

//Carregando Classes de Repositories
builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<IItensNotaRepository, ItensNotaRepository>();

builder.Services.AddScoped<RequisicaoService>();
builder.Services.AddScoped<IRequisicaoRepository, RequisicaoRepository>();
builder.Services.AddScoped<ItensRequisicaoService>();
builder.Services.AddScoped<IItensRequisicaoRepository, ItensRequisicaoRepository>();

builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<EstoqueService>(); 

builder.Services.AddScoped<EntradaProdutoService>();
builder.Services.AddScoped<SaidaProdutosService>();

builder.Services.AddScoped<ILogStrategy, CsvLogStrategy>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

var url = "https://localhost:7062/swagger/index.html";
if(!app.Environment.IsDevelopment())
{
    Process.Start(new ProcessStartInfo
    {
        FileName = url,
        UseShellExecute = true
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
