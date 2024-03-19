using Progetto01_Edicola.Classes;

namespace Progetto01_Edicola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Controllo esistenza file e lettura dei file
            Edicola.checkFiles();

            Console.WriteLine(Edicola.stampaTopSellers());

            int? risposta = 0;

            int? rispostaSottoMenu;

            do
            {
                try
                {
                    Console.WriteLine("\n0.Esci\n1.Gestione inventario\n2.Gestione vendite\n" +
                        "3.Ricerca e filtraggio\n4.Gestione sottoscrizioni\n");
                    risposta = Convert.ToInt32((Console.ReadLine()));

                    //Controllo risposta
                    while (risposta == null || risposta < 0 || risposta > 4)
                    {
                        Console.Write("\nValore non valido. Inserire nuovo valore: ");
                        risposta = Convert.ToInt32((Console.ReadLine()));
                    }

                    #region Menu 1 - Gestione inventario
                    while (risposta == 1)
                    {
                        Console.WriteLine("\n    0.Torna indietro\n    1.Aggiungi pubblicazione\n" +
                            "    2.Rimuovi pubblicazione\n    3.Aggiorna stock pubblicazione\n" +
                            "    4.Visualizza inventario\n    5.Svuota inventario");
                        rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));

                        //Controllo risposta
                        while (rispostaSottoMenu == null || rispostaSottoMenu < 0 || rispostaSottoMenu > 5)
                        {
                            Console.Write("\nValore non valido. Inserire nuovo valore: ");
                            rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));
                        }

                        if (rispostaSottoMenu == 0)
                            break;

                        switch (rispostaSottoMenu)
                        {
                            //Aggiungi pubblicazione
                            case 1: 
                                Edicola.aggiungiPubblicazione();
                                break;

                            //Rimuovi pubblicazione
                            case 2:
                                Edicola.rimuoviPubblicazione();
                                break;

                            //Aggiorna stock di una pubblicazione
                            case 3:
                                Edicola.updateStock();
                                break;

                            //Visualizza inventario
                            case 4:
                                Console.WriteLine(Edicola.stampaInventario());
                                break;

                            //Svuota inventario
                            case 5:
                                Edicola.svuotaInventario();
                                break;
                        }
                    }
                    #endregion Fine Menu 1

                    #region Menu 2 - Gestione vendite
                    while (risposta == 2)
                    {
                        Console.WriteLine("\n    0.Torna indietro\n    1.Vendita di pubblicazioni\n" +
                            "    2.Visualizza storico vendite\n");
                        rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));

                        //Controllo risposta
                        while (rispostaSottoMenu == null || rispostaSottoMenu < 0 || rispostaSottoMenu > 2)
                        {
                            Console.Write("\nValore non valido. Inserire nuovo valore: ");
                            rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));
                        }

                        if (rispostaSottoMenu == 0)
                            break;

                        switch (rispostaSottoMenu)
                        {
                            //Vendi una pubblicazione
                            case 1:
                                Edicola.vendiPubblicazione();
                                break;

                            //Visualizza storico vendite
                            case 2:
                                Edicola.storicoVendite();
                                break;

                        }
                    }
                    #endregion Fine Menu 2

                    #region Menu 3 - Ricerca e filtraggio
                    while (risposta == 3)
                    {
                        Console.WriteLine("\n    0.Torna indietro\n    1.Cerca per termine specifico\n" +
                            "    2.Cerca per termine generale\n" +
                            "    3.Visualizza elenco ordinato per stock\n");
                        rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));

                        //Controllo risposta
                        while (rispostaSottoMenu == null || rispostaSottoMenu < 0 || rispostaSottoMenu > 3)
                        {
                            Console.Write("\nValore non valido. Inserire nuovo valore: ");
                            rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));
                        }

                        if (rispostaSottoMenu == 0)
                            break;

                        switch (rispostaSottoMenu)
                        {
                            //Cerca per termine specifico
                            case 1:
                                Edicola.cercaTermine();
                                break;

                            //Cerca per termine generale                            
                            case 2:
                                Edicola.cercaParola();
                                break;

                            //Visualizza elenco ordinato per stock
                            case 3:
                                Edicola.filtraPerStock();
                                break;

                        }
                    }
                    #endregion Fine Menu 3

                    #region Menu 4 - Gestione sottoscrizioni
                    while (risposta == 4)
                    {
                        Console.WriteLine("\n    0.Torna indietro\n    1.Aggiungi sottoscrizione\n" +
                            "    2.Rimuovi sottoscrizione\n    3.Visualizza programma sottoscrizoni\n");
                        rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));

                        //Controllo risposta
                        while (rispostaSottoMenu == null || rispostaSottoMenu < 0 || rispostaSottoMenu > 3)
                        {
                            Console.Write("\nValore non valido. Inserire nuovo valore: ");
                            rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));
                        }

                        if (rispostaSottoMenu == 0)
                            break;

                        switch (rispostaSottoMenu)
                        {
                            //Aggiungi sottoscrizione
                            case 1:
                                Edicola.aggiungiSottoscrizione();
                                break;

                            //Rimuovi sottoscrizione
                            case 2:
                                Edicola.rimuoviSottoscrizione();
                                break;

                            //Visualizza programma sottoscrizoni
                            case 3:
                                Edicola.mostraSottoscrizioni();
                                break;

                        }
                    }
                    #endregion Fine Menu 4

                }
                catch { }
            } while (risposta != 0);
        }
    }
}
