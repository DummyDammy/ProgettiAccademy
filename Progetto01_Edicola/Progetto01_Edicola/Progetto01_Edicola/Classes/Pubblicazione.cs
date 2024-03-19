using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto01_Edicola.Classes
{
    internal class Pubblicazione
    {
        public int Vendite { get; set; } = 0;
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Titolo { get; set; }
        public string? Categoria { get; set;}
        public string? DataPubblicazione { get; set; }
        public int? Stock { get; set; }

        public override string ToString()
        {
            return $"Id.{Id} | {Tipo} | Titolo: {Titolo} | Categoria: {Categoria} | " +
                $"Uscita: {DataPubblicazione} | Quantitá: {Stock}";
        }

        public virtual string ToCSV()
        {
            return $"{Id};{Vendite};{Tipo};{Titolo};{Categoria};{DataPubblicazione};{Stock}";
        }

        public virtual string ToSearch() 
        {
            return $"{Titolo}{Categoria}";
        }
    }
}