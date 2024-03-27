using System;
using System.Collections.Generic;

namespace ProgettoWPF_GestioneAbiti.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Marca { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public int CategoriaRif { get; set; }

    public virtual Categorium CategoriaRifNavigation { get; set; } = null!;

    public virtual ICollection<Variazione> Variaziones { get; set; } = new List<Variazione>();
}
