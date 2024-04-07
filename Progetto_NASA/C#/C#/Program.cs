using C_.Controllers;
using C_.Models;
using C_.Repositories;
using C_.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace C_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<NASAContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<SistemaRepository>();
            builder.Services.AddScoped<SistemaController>();
            builder.Services.AddScoped<SistemaService>();
            builder.Services.AddScoped<CorpoService>();
            builder.Services.AddScoped<CorpoRepository>();
            builder.Services.AddScoped<CorpoController>();

            var app = builder.Build();

            app.UseCors(builder =>
                    builder
                    .WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader());

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
