using System;
using System.Collections.Generic;

namespace ProgettoWPF_Gestione_Abiti.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Ordine> Ordines { get; set; } = new List<Ordine>();
}
