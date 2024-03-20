using Progetto_PrestitoLibri.DAL;
using Progetto_PrestitoLibri.Models;
using Progetto_PrestitoLibri.Utilities;

namespace Progetto_PrestitoLibri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UtenteDAL.getInstance().findAll();
            ////UtenteDAL.getInstance().insert(new Utente() { Nome = "Utente3Nome", Cognome = "Utente3Cognome", Email = "utente3@email.com" });
            ////Console.WriteLine(UtenteDAL.getInstance().findById(1));
            //Console.WriteLine(UtenteDAL.getInstance().stampaLista());

            LibroDAL.getInstance().findAll();
            //LibroDAL.getInstance().insert(new Libro() { Titolo = "libro2", DataPubblicazione = new DateTime(2020, 12, 12), isDisponibile = true });
            //Console.WriteLine(LibroDAL.getInstance().stampaLista());
            Console.WriteLine(LibroDAL.getInstance().stampaDisponibili());
        }
    }
}
