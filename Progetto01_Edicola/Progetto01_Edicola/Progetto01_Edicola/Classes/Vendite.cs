using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto01_Edicola.Classes
{
    internal class Vendita
    {
        string DataVendita { get; set; } = DateTime.Now.ToString("dd/mm/yyyy");
        Pubblicazione PubblicazioneVenduta { get; set; }

        public Vendita(Pubblicazione pubblicazione)
        {
            PubblicazioneVenduta = pubblicazione;
        }

        public Vendita(Pubblicazione pubblicazione, string data)
        {
            PubblicazioneVenduta = pubblicazione;
            DataVendita = data;
        }

        public override string ToString()
        {
            if (PubblicazioneVenduta.GetType() == typeof(Giornale))
            {
                Giornale temp = (Giornale)PubblicazioneVenduta;
                return $"{DataVendita}: {temp.ToString()};";
            }
            else
            {
                Rivista temp = (Rivista)PubblicazioneVenduta;
                return $"{DataVendita}: {temp.ToString()};";
            }
        }

        public string ToCSV()
        {
            if (PubblicazioneVenduta.GetType() == typeof(Giornale))
            {
                Giornale temp = (Giornale)PubblicazioneVenduta;
                return $"{temp.ToCSV()};{DataVendita}";
            }
            else 
            {
                Rivista temp = (Rivista)PubblicazioneVenduta;
                return $"{temp.ToCSV()};{DataVendita}";
            }
        }
    }
}