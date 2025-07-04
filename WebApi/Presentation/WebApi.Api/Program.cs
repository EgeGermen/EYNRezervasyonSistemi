using WebApi.Persistence; //BUNU DA EKLEMEYİ UNUTMA !!!!!!!!!
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi.Application.Features.Commands.AppUser.CreateUser;


var builder = WebApplication.CreateBuilder(args);


// 2) CORS politikası
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});


builder.Services.AddPersistenceServices(); //!!!!!!!!!!!11
//Bu satır eklenen servisleri program başladığında çağırıp açılması için servis kısmında tanımlanır
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));


// 3) Controller ve OpenAPI/Swagger/Scalar
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddOpenApi();  // Scalar için




var app = builder.Build();



// (Opsiyonel) HTTP → HTTPS yönlendirmesi
app.UseHttpsRedirection();
// CORS'ı en başta devreye al
app.UseCors("AllowAll");
// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();




// Scalar/OpenAPI sadece development'da
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
