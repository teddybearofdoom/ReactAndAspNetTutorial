global using FastEndpoints;
global using FastEndpoints.Security;
global using FluentValidation;
global using AceSolar.Api.Auth;
global using MongoDB.Entities;

using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using AceSolarCRM.Infrastructure;




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth(builder.Configuration["JwtSigninKey"]!);
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "My React Tutorial Test with Asp.NET";
    settings.Version = "v1";
});


var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults()); 

app.Run();

