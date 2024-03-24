using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Progetto_GestioneEventi.Models;

public partial class Partecipante
{
    public int PartecipanteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Evento> EventoRifs { get; set; } = new List<Evento>();

    public override string ToString()
    {
       return $"Id:{PartecipanteId} | Nome:{Nome} | Cognome:{Cognome} | Email:{Email}";
    }

    public string ToCSV()
    {
        return $"{PartecipanteId};{Nome};{Cognome};{Email}";
    }
}
