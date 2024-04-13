using Microsoft.EntityFrameworkCore;

namespace C_.Models
{
    public class MarioKartContext : DbContext
    {
        public MarioKartContext(DbContextOptions<MarioKartContext> options) : base(options) { }

        public DbSet<Personaggio> Personaggi { get; set; }

        public DbSet<Giocatore> Giocatori { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Giocatore>()
                .HasMany(e => e.Personaggi)
                .WithOne(e => e.Giocatore)
                .HasForeignKey(e => e.GiocatoreRIF);
        }

    }
}
