using Microsoft.EntityFrameworkCore;

namespace Progetto_Chat.Models
{
    public class ProgettoChatContext : DbContext
    {
        public ProgettoChatContext(DbContextOptions<ProgettoChatContext> options) : base(options) { }

        public DbSet<Utente> Utenti { get; set; }
    }
}
