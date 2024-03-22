using System;
using System.Collections.Generic;

namespace Progetto_Eventi.Models;

public partial class Evento
{
    public int EventoId { get; set; }

    public string Nome { get; set; } = null!;

    public DateOnly DataEvento { get; set; }

    public string Luogo { get; set; } = null!;

    public int Capacita { get; set; }

    public int? PartecipanteRif { get; set; }

    public int? RisorsaRif { get; set; }

    public virtual Partecipante? PartecipanteRifNavigation { get; set; }

    public virtual Risorsa? RisorsaRifNavigation { get; set; }
}
