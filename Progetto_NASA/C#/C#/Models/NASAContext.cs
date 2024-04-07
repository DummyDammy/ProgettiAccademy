using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace C_.Models
{
    public class NASAContext : DbContext
    {
        public NASAContext(DbContextOptions<NASAContext> options) : base(options) { }

        public DbSet<Sistema> Sistemi { get; set; }

        public DbSet<Corpo> Corpi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corpo>()
               .HasMany(e => e.ListaSistemi)
               .WithMany(e => e.ListaCorpi)
               .UsingEntity(
                   "SistemaCorpo",
                   l => l.HasOne(typeof(Sistema)).WithMany().HasForeignKey("SistemaRIF").HasPrincipalKey(nameof(Sistema.SistemaID)),
                   r => r.HasOne(typeof(Corpo)).WithMany().HasForeignKey("CorpoRIF").HasPrincipalKey(nameof(Corpo.CorpoID)),
                   j => j.HasKey("SistemaRIF", "CorpoRIF"));

            modelBuilder.Entity<Sistema>()
               .HasMany(e => e.ListaCorpi)
               .WithMany(e => e.ListaSistemi)
               .UsingEntity(
                   "SistemaCorpo",
                   l => l.HasOne(typeof(Corpo)).WithMany().HasForeignKey("CorpoRIF").HasPrincipalKey(nameof(Corpo.CorpoID)),
                   r => r.HasOne(typeof(Sistema)).WithMany().HasForeignKey("SistemaRIF").HasPrincipalKey(nameof(Sistema.SistemaID)),
                   j => j.HasKey("SistemaRIF", "CorpoRIF"));
        }
    }
}
