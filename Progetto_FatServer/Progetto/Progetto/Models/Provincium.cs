using System;
using System.Collections.Generic;

namespace Progetto.Models;

public partial class Provincium
{
    public int ProvinciaId { get; set; }

    public string Provincia { get; set; } = null!;

    public virtual ICollection<Impiegato> Impiegatos { get; set; } = new List<Impiegato>();
}
