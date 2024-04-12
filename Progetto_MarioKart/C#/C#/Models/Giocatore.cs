using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C_.Models
{
    [Table("Giocatore")]
    public class Giocatore
    {
        public int GiocatoreID { get; set; }

        public string Nome { get; set; } = null!;

        public int Crediti { get; set; } = 10;

        public string Colore { get; set; } = null!;

        public List<Personaggio> Personaggi { get; set; } = new List<Personaggio>();

    }
}
