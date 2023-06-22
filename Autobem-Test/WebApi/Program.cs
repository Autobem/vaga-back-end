using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Service;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database

builder.Services.AddDbContext<BaseContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion Database

#region Dependency Injection

// Service
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

// Repository
builder.Services.AddScoped<IBaseRepository<Owner>, BaseRepository<Owner>>();
builder.Services.AddScoped<IBaseRepository<Vehicle>, BaseRepository<Vehicle>>();

#endregion Dependency Injection

#region Mapper

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Owner, Owner>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion Mapper

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