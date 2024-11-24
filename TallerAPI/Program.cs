using Microsoft.EntityFrameworkCore;
using Taller.infraestructure;
using Taller.infraestructure.Repositories;
using Taller.infraestructure.interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IHistorialMantenimientoRepository, HistorialMantenimientoRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TallerVehiculosContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("TallerBdContext")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
