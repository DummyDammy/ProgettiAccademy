using System;
using System.Collections.Generic;

namespace Progetto_Eventi.Models;

public partial class Risorsa
{
    public int RisorsaId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public int Quantita { get; set; }

    public decimal Prezzo { get; set; }

    public string Fornitore { get; set; } = null!;

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
