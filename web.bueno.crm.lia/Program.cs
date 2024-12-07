using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.infraestructure.Contexts;
using web.bueno.crm.infraestructure.Repositories;
using web.bueno.crm.aplication;
using web.bueno.crm.aplication.Services;
using web.bueno.crm.infraestructure.Services;
using web.bueno.crm.lia.Common.Security;


var builder = WebApplication.CreateBuilder(args);

//se configura los controllers y su respuesta json
builder.Services.AddControllers().AddJsonOptions(x => {
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//se agrega repositorios
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

//se agrega el contexto de la bd
var connectionString = builder.Configuration.GetConnectionString("CRMLia");
builder.Services.AddDbContext<CrmLiaContext>(x => x.UseSqlServer(connectionString));

//se agrega injeccion por clases static
builder.Services.AddApplicationDependencies();
builder.Services.AddAuthenticationByJWT();


var app = builder.Build();

//se habilita swagger en dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
