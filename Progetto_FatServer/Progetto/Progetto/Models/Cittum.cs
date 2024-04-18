using System;
using System.Collections.Generic;

namespace Progetto.Models;

public partial class Cittum
{
    public int CittaId { get; set; }

    public string Citta { get; set; } = null!;

    public virtual ICollection<Impiegato> Impiegatos { get; set; } = new List<Impiegato>();
}
