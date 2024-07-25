using Microsoft.EntityFrameworkCore;
using EconomiaFacilApp.Libraries.Infrastructure.Data.Context;
using EconomiaFacilApp.Libraries.Infrastructure.Data.Repositories;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Repositories;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Services;
using EconomiaFacilApp.Libraries.Domain.Services;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Application.ServiceApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IDespesaRepository, DespesaRepository>();

builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<IDespesaService, DespesaService>();

builder.Services.AddTransient<ICategoriaServiceApp, CategoriaServiceApp>();
builder.Services.AddTransient<IDespesaServiceApp, DespesaServiceApp>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
