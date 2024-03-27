using System;
using System.Collections.Generic;

namespace ProgettoWPF_Gestione_Abiti.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public DateTime DataOrdine { get; set; }

    public DateTime? DataRitiro { get; set; }

    public int Quantita { get; set; }

    public int VariazioneRif { get; set; }

    public int UtenteRif { get; set; }

    public virtual Utente UtenteRifNavigation { get; set; } = null!;

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
