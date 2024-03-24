using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Progetto_GestioneEventi.Models;

public partial class Evento
{
    public int EventoId { get; set; }

    public string Nome { get; set; } = null!;

    public DateOnly DataEvento { get; set; }

    public string Luogo { get; set; } = null!;

    public int Capacita { get; set; }

    public virtual ICollection<Partecipante> PartecipanteRifs { get; set; } = new List<Partecipante>();

    public virtual ICollection<Risorsa> RisorsaRifs { get; set; } = new List<Risorsa>();

    public override string ToString()
    {
        return $"Id:{EventoId} | Nome:{Nome} | Data:{DataEvento} | Luogo:{Luogo} | Capacità:{Capacita}";
    }

    public string ToCSV()
    {
        return $"{EventoId};{Nome};{DataEvento};{Luogo};{Capacita}";
    }
}
