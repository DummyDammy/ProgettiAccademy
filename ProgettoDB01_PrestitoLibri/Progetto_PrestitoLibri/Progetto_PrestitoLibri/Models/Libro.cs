using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_PrestitoLibri.Models
{
    internal class Libro
    {
        public int? Id { get; set; }
        public string? Titolo {  get; set; }
        public DateTime? DataPubblicazione { get; set; }
        public bool isDisponibile { get; set; } = true;
        public List<Prestito> Prestiti { get; set; } = new List<Prestito>();
        public override string ToString()
        {
            return $"{Id} {Titolo} {DataPubblicazione} {isDisponibile}";
        }
    }
}
