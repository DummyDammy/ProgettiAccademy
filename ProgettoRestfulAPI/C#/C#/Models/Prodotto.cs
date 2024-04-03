using System;
using System.Collections.Generic;

namespace C_.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string? Codice { get; set; }

    public string? Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public decimal? Prezzo { get; set; }

    public int Quantita { get; set; }

    public string? Categoria { get; set; } = null!;

    public DateTime? DataCreazione { get; set; }
}
