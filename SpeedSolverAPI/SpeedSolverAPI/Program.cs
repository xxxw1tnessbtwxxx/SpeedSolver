using Microsoft.EntityFrameworkCore;
using SpeedSolverAPI.MigrationHelper;
using SpeedSolverDatabase;
using System.Reflection;
using System.Text;
using AutoMapper;
using SpeedSolverAPI.Mapper.Profiles;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabaseAccess.Repo;
using SpeedSolverDatabaseAccess.Repo.abc;
using SpeedSolverDatabaseAccess.Services;
using SpeedSolverDatabaseAccess.Services.abc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SpeedSolverCore.JwtProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SpeedSolver OpenAPI",
        Version = "v1",
    });

    // Настройка JWT аутентификации в Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Для доступа к endpoint'ам, требующие JWT авторизацию - в поле ниже введите полученный токен при авторизации. \r\n\r\nВНИМАНИЕ! Токен действителен 24 часа.\r\n\r\nФормат ввода: 'Bearer egqa.ds.1.3342'",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<SpeedContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DeployDatabase"));
});
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = false,
            ValidateActor = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtProvider.KEY))
        };
    });

builder.Services.AddAuthorization();
// Scopes

builder.Services.AddScoped<Service<UserEntity>, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(swag =>
    {
        swag.RouteTemplate = "speedsolver/api/swagger/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/speedsolver/api/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "speedsolver/api/swagger";
    });
    app.ApplyMigration();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.MapControllers();

app.Run();


public partial class Program { }