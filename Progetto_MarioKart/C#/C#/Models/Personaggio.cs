using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C_.Models
{
    [Table("Personaggio")]
    public class Personaggio
    {
        public int PersonaggioID { get; set; }

        public string Nome { get; set; } = null!;

        public string Categoria { get; set; } = null!;

        public string Mezzo { get; set; } = null!;

        public int Costo { get; set; }

        public int? GiocatoreRIF { get; set; }

        [JsonIgnore]
        public Giocatore? Giocatore { get; set; }
    }
}
