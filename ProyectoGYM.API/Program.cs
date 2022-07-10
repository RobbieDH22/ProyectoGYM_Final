
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoGYM.DOMAIN.Core.Interfaces;
using ProyectoGYM.DOMAIN.Infrastructure.Data;
using ProyectoGYM.DOMAIN.Infrastructure.Mapping;
using ProyectoGYM.DOMAIN.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProductosRepository, ProductosRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Get DevConnection
var cnx = builder.Configuration.GetConnectionString("DevConnection");
//Add DbContext
builder.Services.AddDbContext<GYMContext>(options => options.UseSqlServer(cnx));
// Add AutommaperProfile
  var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new AutomapperProfile());
    });
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

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
