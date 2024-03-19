using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto01_Edicola.Classes
{
    internal class Clienti
    {
        public int Id { get; set; }
        public int QuantitaSottoscrizioni { get; set; } = 0;
        public string? Nome { get; set; }
        public string? Cognome { get; set;}
        public List<Pubblicazione> ListaSottoscrizioni { get; set; } = new List<Pubblicazione>();

        public Clienti(int id, string? nome, string? cognome,int quantita, List<Pubblicazione> listaSottoscrizioni)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            QuantitaSottoscrizioni = quantita;
            ListaSottoscrizioni = listaSottoscrizioni;
        }

        public Clienti() { }

        public override string ToString()
        {
            if (QuantitaSottoscrizioni == 1)
                return $"ID.{Id} | Nominativo: {Nome} {Cognome} | Ha: 1 sottoscrizione.";
            return $"ID.{Id} | Nominativo: {Nome} {Cognome} | Ha: {QuantitaSottoscrizioni} sottoscrizioni.";
        }

        public string ToCSV()
        {
            string stringa = "";

            foreach (Pubblicazione sottoscrizione in ListaSottoscrizioni)
                stringa += sottoscrizione.Id + "|";

            return $"{Id};{Nome};{Cognome};{QuantitaSottoscrizioni};{stringa}";
        }
    }
}