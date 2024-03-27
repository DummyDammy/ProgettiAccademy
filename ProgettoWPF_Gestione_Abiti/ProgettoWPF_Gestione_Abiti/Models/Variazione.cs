using System;
using System.Collections.Generic;

namespace ProgettoWPF_Gestione_Abiti.Models;

public partial class Variazione
{
    public int VariazioneId { get; set; }

    public string Taglia { get; set; } = null!;

    public decimal Prezzo { get; set; }

    public string Colore { get; set; } = null!;

    public int Quantita { get; set; }

    public int ProdottoRif { get; set; }

    public virtual ICollection<Offertum> Offerta { get; set; } = new List<Offertum>();

    public virtual ICollection<Ordine> Ordines { get; set; } = new List<Ordine>();

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;
}
