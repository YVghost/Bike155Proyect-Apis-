using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configura DbContext
builder.Services.AddDbContext<BikeBdMateoOrtegaHerrera>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BikeBdMateoOrtegaHerrera") ?? throw new InvalidOperationException("Connection string 'BikeBdMateoOrtegaHerrera' not found.")));

// Habilita CORS para llamadas desde cualquier origen
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

// Configura Kestrel para escuchar en todas las IPs en puerto 5288
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5288); // Escucha en puerto 5288 todas las interfaces
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Opcional: comenta esta línea si quieres aceptar HTTP sin redireccionar a HTTPS
// app.UseHttpsRedirection();

app.UseCors(); // Activa CORS

app.UseAuthorization();

app.MapControllers();

app.Run();
