using System;
using System.Collections.Generic;

namespace Progetto.Models;

public partial class Impiegato
{
    public int ImpiegatoId { get; set; }

    public string Matricola { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Ruolo { get; set; } = null!;

    public DateOnly DataNascita { get; set; }

    public string ViaResidenza { get; set; } = null!;

    public int RepartoRif { get; set; }

    public int CittaRif { get; set; }

    public int ProvinciaRif { get; set; }

    public virtual Cittum CittaRifNavigation { get; set; } = null!;

    public virtual Provincium ProvinciaRifNavigation { get; set; } = null!;

    public virtual Reparto RepartoRifNavigation { get; set; } = null!;
}
