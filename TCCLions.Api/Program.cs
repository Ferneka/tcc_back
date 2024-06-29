using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data;
using TCCLions.Infrastructure.Data.Repositories;
using TCCLions.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IAtaRepository), typeof(AtaRepository));
builder.Services.AddScoped<IAtaService, AtaService>();
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

