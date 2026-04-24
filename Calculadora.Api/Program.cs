using Calculadora.Application.Interfaces;
using Calculadora.Application.Services;
using Calculadora.Domain.Repository;
using Calculadora.Infrastructure.Context;
using Calculadora.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;  

namespace Calculadora.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Base de datos
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Inyección de dependencias
            builder.Services.AddScoped<ITasaRepository, TasaRepository>();
            builder.Services.AddScoped<IEnvioService, EnvioService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
