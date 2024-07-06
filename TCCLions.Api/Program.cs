using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data;
using TCCLions.Infrastructure.Data.Repositories;
using TCCLions.Infrastructure.Services;
using TCCLions.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(IAtaRepository), typeof(AtaRepository));
builder.Services.AddScoped<IAtaService, AtaService>();
builder.Services.AddScoped(typeof(IComissaoRepository), typeof(ComissaoRepository));
builder.Services.AddScoped<IComissaoService, ComissaoService>();
builder.Services.AddScoped(typeof(ITipoComissaoRepository), typeof(TipoComissaoRepository));
builder.Services.AddScoped<ITipoComissaoService, TipoComissaoService>();
builder.Services.AddScoped(typeof(ITipoDespesaRepository), typeof(TipoDespesaRepository));
builder.Services.AddScoped<ITipoDespesaService, TipoDespesaService>();
builder.Services.AddScoped(typeof(IMembroRepository), typeof(MembroRepository));
builder.Services.AddScoped<IMembroService, MembroService>();
builder.Services.AddScoped(typeof(IDespesaRepository), typeof(DespesaRepository));
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddDbContext<ApplicationDataContext>(opt => 
opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

