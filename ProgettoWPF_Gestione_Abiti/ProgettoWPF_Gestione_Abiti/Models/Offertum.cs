using System;
using System.Collections.Generic;

namespace ProgettoWPF_Gestione_Abiti.Models;

public partial class Offertum
{
    public int OffertaId { get; set; }

    public DateOnly DataInizio { get; set; }

    public DateOnly DataFine { get; set; }

    public int Sconto { get; set; }

    public int VariazioneRif { get; set; }

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
