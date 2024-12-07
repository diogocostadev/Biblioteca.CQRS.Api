using Biblioteca.CQRS.Command.Handlers;
using Biblioteca.CQRS.Domain.Repositories;
using Biblioteca.CQRS.Infrastrucure.Persistence;
using Biblioteca.CQRS.Queries.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionar o DapperDbContext ao contêiner
builder.Services.AddSingleton<DapperDbContext>();

// Registrar a interface do repositório e sua implementação
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

// Registrar os handlers de comandos e consultas
builder.Services.AddScoped<CadastrarLivroCommandHandler>();
builder.Services.AddScoped<ConsultarLivroQueryHandler>();

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