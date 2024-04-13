using C_.Controllers;
using C_.Models;
using C_.Repositories;
using C_.Services;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddDbContext<MarioKartContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<PersonaggioRepository>();
            builder.Services.AddScoped<GiocatoreRepository>();
            builder.Services.AddScoped<PersonaggioService>();
            builder.Services.AddScoped<GiocatoreService>();
            builder.Services.AddScoped<PersonaggioController>();
            builder.Services.AddScoped<GiocatoreController>();

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
