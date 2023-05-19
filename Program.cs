using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Domain.Services;
using VehicleRegistry.Domain.ValueObjects;
using VehicleRegistry.Infrastructure.Contexts;
using VehicleRegistry.Infrastructure.Repositories;
using VehicleRegistry.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container.

// Registra os contextos do banco de dados.
builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Main"));
});
builder.Services.AddDbContext<BusinessContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Main"));
});

// Registra os serviços de domínio.
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<VehicleColorService>();
builder.Services.AddScoped<VehicleFuelService>();
builder.Services.AddScoped<VehicleTypeService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<ModelService>();
builder.Services.AddScoped<OwnerService>();

// Registra os repositórios de persistência.
builder.Services.AddScoped<VehicleRepository>();
builder.Services.AddScoped<VehicleColorRepository>();
builder.Services.AddScoped<VehicleFuelRepository>();
builder.Services.AddScoped<VehicleTypeRepository>();
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<ModelRepository>();
builder.Services.AddScoped<OwnerRepository>();

// Registra os semeadores para popuplar o banco de dados.
builder.Services.AddScoped<VehicleColorSeeder>();
builder.Services.AddScoped<VehicleFuelSeeder>();
builder.Services.AddScoped<VehicleTypeSeeder>();
builder.Services.AddScoped<BrandSeeder>();

// Adiciona o CORS.
builder.Services.AddCors();

// Cria o objeto de dados de autenticação.
var auth = new Auth(
    builder.Configuration["Jwt:Key"] ?? "",
    builder.Configuration["Jwt:Issuer"] ?? "",
    builder.Configuration["Jwt:Audience"] ?? ""
);

// Registra o objeto de dados de autenticação.
builder.Services.AddSingleton<Auth>(provider => auth);

// Adiciona a autenticação para a API.
builder.Services.AddAuthentication(options =>
{
    // Define o esquema de autenticação para OAuth2 com JWT.
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Configura os parâmetros do JWT a serem usados na autenticação das
    // requisições.
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = auth.Issuer,
        ValidAudience = auth.Audience,
        IssuerSigningKey = auth.Key
    };
});
// Adiciona a política de autorização.
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DefaultPolicy", x =>
    {
        // Aplica a exigência de autenticação em todas as rotas.
        x.RequireAuthenticatedUser();
        // Define o JWT como método padrão de autorização nas rotas.
        x.AuthenticationSchemes = new List<string> {
            JwtBearerDefaults.AuthenticationScheme
        };
    });
});

// Registra a identidade padrão como entidade de usuário a ser autenticado.
builder.Services.AddIdentity<User, Role>(options =>
{
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<IdentityContext>()
.AddTokenProvider<DataProtectorTokenProvider<User>>(
    TokenOptions.DefaultProvider
).AddDefaultTokenProviders();
// Registra o gerenciador de usuário.
builder.Services.AddScoped<UserManager<User>>();

// Adiciona os controladores.
builder.Services.AddControllers();
// Ler mais sobre como configurar o Swagger/OpenAPI em
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Adiciona o Swagger para documentação da API.
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    // Habilita o Swagger.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilita o CORS.
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
// Habilita a autorização.
app.UseAuthorization();

// Mapeia os controladores para seus respectivos endpoints e protege todas as
// rotas com a política de autorização adicionada anteriormente.
app.MapControllers().RequireAuthorization("DefaultPolicy");

app.Run();
