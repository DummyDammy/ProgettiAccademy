using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto01_Edicola.Classes
{
    internal class Giornale : Pubblicazione
    {
        public string? Redazione { get; set; }

        public override string ToString()
        {
            return $"Id.{Id} | {Tipo} | Titolo: {Titolo} | Categoria: {Categoria} | " +
                $"Uscita: {DataPubblicazione} | Quantitá: {Stock} | " +
                $"Redazione: {Redazione}";
        }

        public override string ToCSV()
        {
            return $"{Id};{Vendite};{Tipo};{Titolo};{Categoria};{DataPubblicazione};{Stock};{Redazione}";
        }
    }
}