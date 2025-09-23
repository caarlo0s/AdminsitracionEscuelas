using AdminSchool.Api;
using AdminSchool.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar EF Core con SQL Server
builder.Services.AddDbContext<AdminDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,                         // Número máximo de reintentos
            maxRetryDelay: TimeSpan.FromSeconds(10),  // Tiempo máximo de espera entre reintentos
            errorNumbersToAdd: null                   // Códigos de error adicionales (si quieres)
        )
    )
);



var jwtKey = builder.Configuration["Jwt:Key"];
var keyBytges =Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:AdminSchoolUsers"],
        IssuerSigningKey = new SymmetricSecurityKey(keyBytges)

    };
});

// Configurar Swagger/OpenAPI (Swashbuckle)


// Agregar controladores
builder.Services.AddControllers();
builder.Services.ConfiguraAdminSchoolService(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AdminSchool API",
        Version = "v1"
    });
});


var app = builder.Build();

//  Middleware de Swagger solo en desarrollo

app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita el endpoint /swagger/v1/swagger.json
    app.UseSwaggerUI(); // Habilita la interfaz /swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
