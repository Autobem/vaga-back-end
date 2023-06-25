using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Service;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Helpers;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Autobem C# Test Api",
        Description = "An ASP.NET Core Web API for Autobem selective process",
        Contact = new OpenApiContact
        {
            Name = "Access Autobem main site",
            Url = new Uri("https://www.autobembrasil.com.br/")
        },
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @$"To authorize the use of this swagger endpoints, enter the following informations bellow:
                        Bearer (your token)
                        Exactly like that. With space between ""Bearer"" and upper case B on Bearer.
                        If your token is valid, you will be authorized to use this swagger",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = builder.Configuration["Auth0:Client"];
});

#endregion Authentication

#region Database

builder.Services.AddDbContext<BaseContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion Database

#region Dependency Injection

// Service
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

// Repository
builder.Services.AddScoped<IBaseRepository<Owner>, BaseRepository<Owner>>();
builder.Services.AddScoped<IBaseRepository<Vehicle>, BaseRepository<Vehicle>>();
builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();

#endregion Dependency Injection

#region Mapper

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion Mapper

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();