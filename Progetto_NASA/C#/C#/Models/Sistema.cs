using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C_.Models
{
    [Table("Sistema")]
    public class Sistema
    {
        public int SistemaID { get; set; }

        public string? Codice { get; set; } = null!;

        public string? Nome { get; set; } = null!;

        public string? Tipo { get; set; } = null!;

        [JsonIgnore]
        public virtual List<Corpo> ListaCorpi { get; set; } = new List<Corpo>();

    }

}
