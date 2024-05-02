using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Progetto_Chat.Models;
using Progetto_Chat.Repositories;
using Progetto_Chat.Services;
using System.Text;

namespace Progetto_Chat
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

            builder.Services.AddDbContext<ProgettoChatContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<UtenteRepository>();
            builder.Services.AddScoped<UtenteService>();
            builder.Services.AddScoped<StanzaRepository>();
            builder.Services.AddScoped<StanzaService>();
            builder.Services.AddScoped<MessaggioRepository>();
            builder.Services.AddScoped<MessaggioService>();

            builder.Services.AddAuthentication()
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "Chat",
                     ValidAudience = "Utenti",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"))
                 };
             });

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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
