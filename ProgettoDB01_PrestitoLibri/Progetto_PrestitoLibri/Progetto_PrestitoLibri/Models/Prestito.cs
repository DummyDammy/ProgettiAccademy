using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_PrestitoLibri.Models
{
    internal class Prestito
    {
        public int? Id { get; set; }
        public DateTime? DataPrestito { get; set; }
        public DateTime? DataRitorno { get; set; }
        public int UtenteRIF { get; set; }
        public int LibroRIF { get; set; }
    }
}
