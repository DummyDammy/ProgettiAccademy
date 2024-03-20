using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_PrestitoLibri.Models
{
    internal class Utente
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email {  get; set; }

        public override string ToString()
        {
            return $"{Id} {Nome} {Cognome} {Email}";
        }
    }
}
