using GestaoDeRH.Aplicacao.ControlePonto;
using GestaoDeRH.Aplicacao.ControlePonto.Interfaces;
using GestaoDeRH.Aplicacao.FolhaDePagamento;
using GestaoDeRH.Aplicacao.FolhaDePagamento.Interfaces;
using GestaoDeRH.Aplicacao.Notificacoes;
using GestaoDeRH.Aplicacao.Recrutamento;
using GestaoDeRH.Aplicacao.Recrutamento.Interfaces;
using GestaoDeRH.Dominio.ControlePonto;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Infra.BancoDeDados;
using GestaoDeRH.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GestaoDeRhDbContext>(options =>
{
    options.UseSqlite($@"Data Source={Path.Combine("..", "LocalDatabase.db")}");
}, ServiceLifetime.Scoped);


//Incluir repositorios
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<IPontoRepositorio, PontosRepositorio>();

//Incluir Aplicacao
builder.Services.AddScoped<IMarcacaoPonto, MarcacaoPonto>();

builder.Services.AddScoped<IFecharFolhaDePagamento, FecharFolhaDePagamento>();

builder.Services.AddScoped<INotificarColaborador, NotificarColaborador>();

builder.Services.AddScoped<ICriarVaga, CriarVaga>();
builder.Services.AddScoped<INovoCandidato, NovoCandidato>();
builder.Services.AddScoped<IAprovarCandidato, AprovarCandidato>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
