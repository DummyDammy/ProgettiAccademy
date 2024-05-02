using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progetto_Chat.Models
{
    [Table("Utente")]
    public class Utente
    {
        public int UtenteID { get; set; }

        public string Nickname { get; set; } = null!;

        public string Pass { get; set; } = null!;

        public string Email { get; set; } = null!;

        [NotMapped]
        public ICollection<Messaggio> Messaggi { get; set; } = new List<Messaggio>();

        [NotMapped]
        public ICollection<Stanza> Stanze {  get; set; } = new List<Stanza>();
    }
}
