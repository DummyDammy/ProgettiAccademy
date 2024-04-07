using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C_.Models
{
    [Table("Corpo")]
    public partial class Corpo
    {
        public int CorpoID { get; set; }

        public string? Nome { get; set; } = null!;

        public string? Codice { get; set; } = null!;

        public DateOnly? DataScoperta { get; set; }

        public string? Tipo { get; set; } = null!;

        public decimal? Distanza { get; set; }

        public string? Scopritore { get; set; } = "Sconosciuto";

        public decimal? CoordinataAngolare { get; set; }

        public decimal? CoordinataRadiale { get; set; }

        public List<Sistema> ListaSistemi { get; set; } = new List<Sistema>();

    }
}
