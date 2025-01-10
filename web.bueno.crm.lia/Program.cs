using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.infraestructure.Contexts;
using web.bueno.crm.infraestructure.Repositories;
using web.bueno.crm.aplication;
using web.bueno.crm.aplication.Services;
using web.bueno.crm.infraestructure.Services;
using web.bueno.crm.lia.Common.Security;
using web.bueno.crm.infraestructure.Data;

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//se configura los controllers y su respuesta json
builder.Services.AddControllers().AddJsonOptions(x => {
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

//se agrega token
builder.Services.AddSwaggerGen(x =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "por favor ingresa el jwt",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    x.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    x.AddSecurityRequirement(new OpenApiSecurityRequirement{
        { jwtSecurityScheme, Array.Empty<string>() }
    });

    x.SwaggerDoc("v1", new OpenApiInfo { Title = "web.bueno.crm.lia", Version = "v1" });

});

//se agrega configuration del token
builder.Services.AddOptions<TokenSettingOptions>()
    .Bind(builder.Configuration.GetSection("Jwt"));

//se agrega repositorios
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IContactoRepository, ContactoRepository>();
builder.Services.AddTransient<IContactoTelefonoRepository, ContactoTelefonoRepository>();
builder.Services.AddTransient<IContactoCorreoRepository, ContactoCorreoRepository>();

//se agrega cors
builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    x.AddPolicy("dev_policy", c => c.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
});

//se agrega el contexto de la bd
var connectionString = builder.Configuration.GetConnectionString("CRMLia");
builder.Services.AddDbContext<CrmLiaContext>(x => x.UseSqlServer(connectionString));

//se obtiene configuracion del token
var optionsJwtKey = builder.Configuration
        .GetSection("Jwt:Key")
        .Get<string>();

//se agrega injeccion por clases static
builder.Services.AddApplicationDependencies();
builder.Services.AddAuthenticationByJWT(optionsJwtKey);

//Se crea el api
var app = builder.Build();

//se habilita swagger en dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("dev_policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
