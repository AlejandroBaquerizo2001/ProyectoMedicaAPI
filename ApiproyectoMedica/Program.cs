using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using ProyectoMedica.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy("ApiWeb",
    builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()));

builder.Services.AddDbContext<AplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositorioAdquirido, RepositorioAdquirido>();
builder.Services.AddScoped<IRepositorioCita, RepositorioCita>();
builder.Services.AddScoped<IRepositorioDoctor, RepositorioDoctor>();
builder.Services.AddScoped<IRepositorioHistorial, RepositorioHistorial>();
builder.Services.AddScoped<IRepositorioInventario, RepositorioInventario>();
builder.Services.AddScoped<IRepositorioProducto, RepositorioProducto>();
builder.Services.AddScoped<IRepositorioSalida, RepositorioSalida>();
builder.Services.AddScoped<IRepositorioServicios, RepositorioServicios>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ApiWeb");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
