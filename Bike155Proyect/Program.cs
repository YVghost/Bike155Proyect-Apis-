using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BikeBdMateoOrtegaHerrera>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BikeBdMateoOrtegaHerrera") ?? throw new InvalidOperationException("Connection string 'BikeBdMateoOrtegaHerrera' not found.")));

// Habilita CORS para llamadas desde MAUI
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); // ¡Importante! Habilita CORS aquí

app.UseAuthorization();

app.MapControllers();

app.Run();
