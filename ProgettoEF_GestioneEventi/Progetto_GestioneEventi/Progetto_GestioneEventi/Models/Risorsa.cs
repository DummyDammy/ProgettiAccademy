using System;
using System.Collections.Generic;

namespace Progetto_GestioneEventi.Models;

public partial class Risorsa
{
    public int RisorsaId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public int Quantita { get; set; }

    public decimal Prezzo { get; set; }

    public string Fornitore { get; set; } = null!;

    public virtual ICollection<Evento> EventoRifs { get; set; } = new List<Evento>();

    public override string ToString()
    {
        return $"Id:{RisorsaId} | Tipo:{Tipo} | Nome:{Nome} | Quantità:{Quantita} | Prezzo:{Prezzo} | Fornitore:{Fornitore}";
    }

    public string ToCSV()
    {
        return $"{RisorsaId};{Tipo};{Nome};{Quantita};{Prezzo};{Fornitore}";
    }
}
