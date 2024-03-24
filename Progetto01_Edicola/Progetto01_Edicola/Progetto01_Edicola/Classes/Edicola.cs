using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto01_Edicola.Classes
{
    internal class Edicola
    {
        static List<Pubblicazione> Inventario { get; set; } = new List<Pubblicazione>();
        static List<Clienti> ListaClienti { get; set; } = new List<Clienti>();
        static List<Vendita> CronologiaVendite { get; set; } = new List<Vendita>();

        static string pathInventario = "C:\\Users\\Utente\\Desktop\\Inventario.txt";
        static string pathSottoscrizioni = "C:\\Users\\Utente\\Desktop\\Sottoscrizioni.txt";
        static string pathVendite = "C:\\Users\\Utente\\Desktop\\Vendite.txt";

        #region Gestione programma
        //Crea i file nel caso non esistono e li legge per rimepire le liste
        public static void checkFiles()
        {
            //Controllo file Inventario.txt
            try
            {
                using(StreamReader sr = new StreamReader(pathInventario))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(";");

                        //Allora é giornale
                        if (words[2].Equals("Giornale")) 
                        {                           
                            Pubblicazione giornale = new Giornale();   
                            
                            if (giornale.GetType() == typeof(Giornale))
                            {
                                Giornale temp = (Giornale)giornale;
                                temp.Id = Convert.ToInt32(words[0]);
                                temp.Vendite = Convert.ToInt32(words[1]);
                                temp.Tipo = words[2];
                                temp.Titolo = words[3];
                                temp.Categoria = words[4];
                                temp.DataPubblicazione = words[5];
                                temp.Stock = Convert.ToInt32(words[6]);                                
                                temp.Redazione = words[7];
                                Inventario.Add(temp);
                            }
                        }

                        //Allora é rivista
                        if (words[2].Equals("Rivista"))
                        {
                            Pubblicazione rivista = new Rivista();

                            if (rivista.GetType() == typeof(Rivista))
                            {
                                Rivista temp = (Rivista)rivista;
                                temp.Id = Convert.ToInt32(words[0]);
                                temp.Vendite = Convert.ToInt32(words[1]);
                                temp.Tipo = words[2];
                                temp.Titolo = words[3];
                                temp.Categoria = words[4];
                                temp.DataPubblicazione = words[5];
                                temp.Stock = Convert.ToInt32(words[6]);
                                Inventario.Add(temp);
                            }
                        }
                    }
                }
            } catch 
            {
                using (StreamWriter sw = new StreamWriter(pathInventario))
                {
                    sw.WriteLine();
                }
            }

            //Controllo Sottoscrizoni.txt
            try
            {
                using (StreamReader sr = new StreamReader(pathSottoscrizioni))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(";");

                        string[] Ids = words[4].Trim().Split("|");

                        List<Pubblicazione> listaTemp = new List<Pubblicazione>();

                        for(int i = 0; i < Ids.Length - 1; i++)
                        {
                            foreach (Pubblicazione pub in Inventario)
                            {
                                if (pub.Id == Convert.ToInt32(Ids[i]) && !Ids[i].Equals(""))
                                {
                                    if (pub.GetType() == typeof(Giornale))
                                    {
                                        Giornale temp = (Giornale)pub;
                                        listaTemp.Add(temp);
                                        
                                    }
                                    if (pub.GetType() == typeof(Rivista))
                                    {
                                        Rivista temp = (Rivista)pub;
                                        listaTemp.Add(temp);
                                    }
                                }
                            }
                        }

                        ListaClienti.Add(new Clienti(Convert.ToInt32(words[0]), words[1], words[2], Convert.ToInt32(words[3]), listaTemp));
                    }
                }
            }
            catch
            {
                using (StreamWriter sw = new StreamWriter(pathSottoscrizioni))
                {
                    sw.WriteLine();
                }
            }

            //Controllo Vendite.txt
            try
            {
                using (StreamReader sr = new StreamReader(pathVendite))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(";");

                        //Allora é giornale
                        if (words[2].Equals("Giornale"))
                        {
                            Pubblicazione giornale = new Giornale();

                            if (giornale.GetType() == typeof(Giornale))
                            {
                                Giornale temp = (Giornale)giornale;
                                temp.Id = Convert.ToInt32(words[0]);
                                temp.Vendite = Convert.ToInt32(words[1]);
                                temp.Tipo = words[2];
                                temp.Titolo = words[3];
                                temp.Categoria = words[4];
                                temp.DataPubblicazione = words[5];
                                temp.Stock = Convert.ToInt32(words[6]);
                                temp.Redazione = words[7];
                                CronologiaVendite.Add(new Vendita(temp, words[8]));
                            }
                        }

                        //Allora é rivista
                        if (words[2].Equals("Rivista"))
                        {
                            Pubblicazione rivista = new Rivista();

                            if (rivista.GetType() == typeof(Rivista))
                            {
                                Rivista temp = (Rivista)rivista;
                                temp.Id = Convert.ToInt32(words[0]);
                                temp.Vendite = Convert.ToInt32(words[1]);
                                temp.Tipo = words[2];
                                temp.Titolo = words[3];
                                temp.Categoria = words[4];
                                temp.DataPubblicazione = words[5];
                                temp.Stock = Convert.ToInt32(words[6]);
                                CronologiaVendite.Add(new Vendita(temp, words[7]));
                            }
                        }
                    }
                }
            }
            catch
            {
                using (StreamWriter sw = new StreamWriter(pathVendite))
                {
                    sw.WriteLine();
                }
            }
        }

        //Stampa i TopSellers
        public static string stampaTopSellers()
        {
            int cont = 0;

            List<Pubblicazione> pubblicaziones = Inventario.OrderBy(x => x.Vendite).ToList();

            if (pubblicaziones.Count > 0)
            {
                string stringa = "\n";

                for (int i = pubblicaziones.Count - 1; i >= 0; i--)
                {
                    if (pubblicaziones[i].GetType() == typeof(Giornale))
                    {
                        Giornale temp = (Giornale)pubblicaziones[i];
                        cont += 1;
                        stringa += $"{cont}:" + temp.ToString() + "\n";
                    }

                    if (pubblicaziones[i].GetType() == typeof(Rivista))
                    {
                        Rivista temp = (Rivista)pubblicaziones[i];
                        cont += 1;
                        stringa += $"{cont}:" + temp.ToString() + "\n";
                    }

                    if (cont == 5)
                        break;
                }

                return "Top sellers:\n" + stringa;
            }

            return "";
        }

        //Sovrascrivere il file .txt in input
        public static void overwrite(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Utente\\Desktop\\Eventi.txt"))
                {
                    foreach (Pubblicazione pubblicazione in Inventario)
                    {
                        if (pubblicazione != null &&
                            pubblicazione.GetType() == typeof(Giornale))
                        {
                            Giornale temp = (Giornale)pubblicazione;
                            sw.WriteLine(temp.ToCSV());
                        }

                        if (pubblicazione != null &&
                            pubblicazione.GetType() == typeof(Rivista))
                        {
                            Rivista temp = (Rivista)pubblicazione;
                            sw.WriteLine(temp.ToCSV());
                        }
                    }
                }
            }
            catch { }

            //Lista sottoscrizioni
            if (path.Equals(pathSottoscrizioni))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (Clienti cliente in ListaClienti)
                        {
                            if (cliente != null)
                            {
                                sw.WriteLine(cliente.ToCSV());
                            }
                        }
                    }
                }
                catch { }
            }

            //Lista vendite
            if (path.Equals(pathVendite))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (Vendita vendita in CronologiaVendite)
                        {
                            if (vendita != null)
                            {
                                sw.WriteLine(vendita.ToCSV());
                            }
                        }
                    }
                }
                catch { }
            }
        }

        //Prende un ID disponibile per la lista degli inventari
        public static int getUnusedIDInventario()
        {
            try
            {
                int id = Inventario[Inventario.Count - 1].Id + 1;

                return id;
            }
            catch { return 1;}

        }

        //Prende un ID disponibile per la lista degi clienti
        public static int getUnusedIDClienti()
        {
            try
            {
                int id = ListaClienti[ListaClienti.Count - 1].Id + 1;

                return id;
            }
            catch { return 1; }

        }

        #endregion Fine gestione programma

        #region Menu 1 - Gestione inventario

        //1.Aggiungi pubblicazione
        public static void aggiungiPubblicazione()
        {
            try
            {
                Console.WriteLine("\n        0.Torna indietro\n        1.Aggiungi giornale\n" +
                    "        2.Aggiungi rivista\n");
                int? risposta = Convert.ToInt32((Console.ReadLine()));

                //Controllo risposta
                while (risposta == null || risposta < 0 || risposta > 2)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }

                switch (risposta)
                {
                    //Crea giornale
                    case 1: 
                        Pubblicazione giornale = new Giornale();

                        Console.Write("Inserire titolo: ");
                        string? titoloGiornale = Console.ReadLine();

                        Console.Write("Inserire categoria: ");
                        string? categoriaGiornale = Console.ReadLine();

                        Console.Write("Inserire giorno di pubblicazione: ");
                        int giornoPubblicazioneGiornale = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserire mese di pubblicazione: ");
                        int mesePubblicazioneGiornale = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserire anno di pubblicazione: ");
                        int annoPubblicazioneGiornale = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserire quantita in stock: ");
                        int quantitaStockGiornale = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserire redazione: ");
                        string? redazioneGiornale = Console.ReadLine();

                        giornale.Id = getUnusedIDInventario();
                        giornale.Tipo = "Giornale";
                        giornale.Titolo = titoloGiornale;
                        giornale.Categoria = categoriaGiornale;
                        giornale.DataPubblicazione = $"{giornoPubblicazioneGiornale}/{mesePubblicazioneGiornale}/{annoPubblicazioneGiornale}";
                        giornale.Stock = quantitaStockGiornale;

                        if (giornale.GetType() == typeof(Giornale))
                        {
                            Giornale temp = (Giornale)giornale;
                            temp.Redazione = redazioneGiornale;
                            Inventario.Add(temp);
                            Console.WriteLine("\nInserimento riuscito\n");
                        }

                        overwrite(pathInventario);

                        break;

                    //Crea rivista
                    case 2:
                        Pubblicazione rivista = new Rivista();

                        Console.Write("Inserire titolo: ");
                        string? titoloRivista = Console.ReadLine();

                        Console.Write("Inserire categoria: ");
                        string? categoriatitoloRivista = Console.ReadLine();

                        Console.Write("Inserire giorno di pubblicazione: ");
                        int giornoPubblicazionetitoloRivista = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserire mese di pubblicazione: ");
                        int mesePubblicazionetitoloRivista = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserire anno di pubblicazione: ");
                        int annoPubblicazionetitoloRivista = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Inserire quantita in stock: ");
                        int quantitaStockRivista = Convert.ToInt32(Console.ReadLine());

                        rivista.Id = getUnusedIDInventario();
                        rivista.Tipo = "Rivista";
                        rivista.Titolo = titoloRivista;
                        rivista.Categoria = categoriatitoloRivista;
                        rivista.DataPubblicazione = $"{giornoPubblicazionetitoloRivista}/{mesePubblicazionetitoloRivista}/{annoPubblicazionetitoloRivista}";
                        rivista.Stock = quantitaStockRivista;


                        if (rivista.GetType() == typeof(Rivista))
                        {
                            Rivista temp = (Rivista)rivista;
                            Inventario.Add(temp);
                            Console.WriteLine("\nInserimento riuscito\n");
                        }

                        overwrite(pathInventario);

                        break;
                }
            }
            catch { }
        }

        //2.Rimuovi pubblicazione
        public static void rimuoviPubblicazione()
        {
            Console.WriteLine("\n        0.Torna indietro\n        " +
                "1.Rimuovi una pubblicazione\n");
            int? risposta = Convert.ToInt32((Console.ReadLine()));

            //Controllo risposta
            while (risposta == null || risposta < 0 || risposta > 1)
            {
                Console.Write("\nValore non valido. Inserire nuovo valore: ");
                risposta = Convert.ToInt32((Console.ReadLine()));
            }

            if (risposta == 1)
            {
                string stringa = stampaInventario();

                if (!stringa.Equals("\nInventario vuoto"))
                {
                    Console.WriteLine(stringa);
                    Console.Write("\nInserire Id del file da eliminare: ");
                    int? idRicevuto = Convert.ToInt32((Console.ReadLine()));

                    foreach (Pubblicazione pubblicazione in Inventario)
                    {
                        if (pubblicazione.Id == idRicevuto)
                        {
                            Inventario.Remove(pubblicazione);
                            overwrite(pathInventario);
                            Console.WriteLine($"\nEliminazione del file con ID {idRicevuto} compiuta con successo");
                        }
                    }
                }

                else
                    Console.WriteLine(stringa);   
            }
        }

        //3.Aggiorna stock pubblicazione
        public static void updateStock()
        {
            Console.WriteLine("\n        0.Torna indietro\n        " +
                "1.Aggiorna pubblicazione\n");
            int? risposta = Convert.ToInt32((Console.ReadLine()));

            //Controllo risposta
            while (risposta == null || risposta < 0 || risposta > 1)
            {
                Console.Write("\nValore non valido. Inserire nuovo valore: ");
                risposta = Convert.ToInt32((Console.ReadLine()));
            }

            if (risposta == 1)
            {
                string stringa = stampaInventario();

                if (!stringa.Equals("\nInventario vuoto"))
                {
                    Console.WriteLine(stringa);
                    Console.Write("\nInserire Id del file da modificare: ");
                    int? idRicevuto = Convert.ToInt32((Console.ReadLine()));

                    foreach (Pubblicazione pubblicazione in Inventario)
                    {
                        if (pubblicazione.Id == idRicevuto)
                        {
                            try
                            {
                                Console.Write("Inserire nuova quantitá stock: ");
                                pubblicazione.Stock = Convert.ToInt32((Console.ReadLine()));

                                overwrite(pathInventario);
                                Console.WriteLine($"\nEliminazione del file con ID {idRicevuto} compiuta con successo");
                            }
                            catch (Exception) { Console.WriteLine("Valore non valido."); }
                        }
                    }
                }

                else
                    Console.WriteLine(stringa);
            }
        }

        //4.Visualizza inventario
        public static string stampaInventario()
        {
            string stringa = "\n";

            foreach(Pubblicazione pub in Inventario)
            {
                if (pub.GetType() == typeof(Giornale))
                {
                    Giornale temp = (Giornale)pub;
                    stringa += temp.ToString() + "\n";
                }
                if (pub.GetType() == typeof(Rivista))
                {
                    Rivista temp = (Rivista)pub;
                    stringa += temp.ToString() + "\n";
                }
            }

            if (!stringa.Equals("\n"))
                return stringa;

            else
                return "\nInventario vuoto";
        }

        //5.Svuota inventario
        public static void svuotaInventario()
        {
            Console.Write("    Sei sicuro di voler eliminare l'intero inventario?\n" +
                "        0.Annulla\n        1.Procedi");
            int? risposta = Convert.ToInt32((Console.ReadLine()));

            if (risposta == 1)
            {
                Inventario = new List<Pubblicazione>();
                overwrite(pathInventario);
                Console.WriteLine("\nInventario svuotato.");
            }
        } 

        #endregion Fine Menu 1

        #region Menu 2 - Gestione Vendite

        //1.Vendere pubblicazione
        public static void vendiPubblicazione()
        {
            Console.WriteLine("\n        0.Torna indietro\n        " +
                "1.Vendi una pubblicazione\n");
            int? risposta = Convert.ToInt32((Console.ReadLine()));

            //Controllo risposta
            while (risposta == null || risposta < 0 || risposta > 1)
            {
                Console.Write("\nValore non valido. Inserire nuovo valore: ");
                risposta = Convert.ToInt32((Console.ReadLine()));
            }

            if (risposta == 1)
            {
                string stringa = stampaInventario();

                if (!stringa.Equals("\nInventario vuoto"))
                {
                    Console.WriteLine(stringa);
                    Console.Write("\nInserire Id del file da vendere: ");
                    int? idRicevuto = Convert.ToInt32((Console.ReadLine()));

                    foreach (Pubblicazione pubblicazione in Inventario)
                    {
                        if (pubblicazione.Id == idRicevuto)
                        {
                            if (pubblicazione.Stock != 0)
                            {
                                pubblicazione.Vendite += 1;
                                pubblicazione.Stock -= 1;
                                overwrite(pathInventario);
                                CronologiaVendite.Add(new Vendita(pubblicazione));
                                overwrite(pathVendite);
                                Console.WriteLine($"\nVendita della pubblicazione del file con ID {idRicevuto} compiuta con successo");
                            }

                            else
                                Console.WriteLine($"\nPubblicazione con ID {idRicevuto} ha terminato lo stock");

                        }
                    }
                }

                else
                    Console.WriteLine(stringa);
            }
        }

        //2.Visualizza storico vendite
        public static void storicoVendite()
        {
            foreach (Vendita vendita in CronologiaVendite)
            {
                Console.WriteLine(vendita);
            }
        }
        #endregion Fine Menu 2

        #region Menu 3 - Ricerca e filtraggio

        //1.Cerca per termine specifico
        public static void cercaTermine()
        {
            string stringa = "\n";
            Console.WriteLine("\n        0.Torna indietro\n        1.Per titolo\n        " +
                            "2.Per categoria\n        3.Redazione\n");
            int? risposta = Convert.ToInt32((Console.ReadLine()));

            //Controllo risposta
            while (risposta == null || risposta < 0 || risposta > 3)
            {
                Console.Write("\nValore non valido. Inserire nuovo valore: ");
                risposta = Convert.ToInt32((Console.ReadLine()));
            }

            //Ricerca per titolo
            if (risposta == 1)
            {
                Console.WriteLine("\n        Inserire titolo: ");
                string? ricerca = Console.ReadLine();

                foreach (Pubblicazione pubblicazione in Inventario)
                {
                    if (ricerca is not null &&
                        pubblicazione.Titolo is not null &&
                        pubblicazione.Titolo.Equals(ricerca))
                    {
                        if (pubblicazione.GetType() == typeof(Giornale))
                        {
                            Giornale temp = (Giornale) pubblicazione;
                            stringa += temp.ToString() + "\n";
                        }

                        if (pubblicazione.GetType() == typeof(Rivista))
                        {
                            Rivista temp = (Rivista)pubblicazione;
                            stringa += temp.ToString() + "\n";
                        }
                    }
                }

                if (!stringa.Equals("\n"))
                    Console.WriteLine(stringa);

                else
                    Console.WriteLine("Nessuna corrispondenza");
            }

            //Ricerca per categoria
            if (risposta == 2)
            {
                Console.WriteLine("\n        Inserire categoria: ");
                string? ricerca = Console.ReadLine();

                foreach (Pubblicazione pubblicazione in Inventario)
                {
                    if (ricerca is not null &&
                        pubblicazione.Categoria is not null &&
                        pubblicazione.Categoria.ToUpper().Trim().Equals(ricerca.ToUpper().Trim()))
                    {
                        if (pubblicazione.GetType() == typeof(Giornale))
                        {
                            Giornale temp = (Giornale)pubblicazione;
                            stringa += temp.ToString() + "\n";
                        }

                        if (pubblicazione.GetType() == typeof(Rivista))
                        {
                            Rivista temp = (Rivista)pubblicazione;
                            stringa += temp.ToString() + "\n";
                        }
                    }
                }

                if (!stringa.Equals("\n"))
                    Console.WriteLine(stringa);

                else
                    Console.WriteLine("Nessuna corrispondenza");
            }

            //Ricerca per redazione
            if (risposta == 3)
            {
                Console.Write("\n        Inserire redazione: ");
                string? ricerca = Console.ReadLine();

                foreach (Pubblicazione pubblicazione in Inventario)
                {
                    if (pubblicazione.GetType() == typeof(Giornale))
                    {
                        Giornale temp = (Giornale)pubblicazione;

                        if (ricerca is not null &&
                            temp.Redazione is not null &&
                            temp.Redazione.ToUpper().Trim().Equals(ricerca.ToUpper().Trim()))
                        {
                            stringa += temp.ToString() + "\n";
                        }
                    }
                }

                if (!stringa.Equals("\n"))
                    Console.WriteLine(stringa);

                else
                    Console.WriteLine("Nessuna corrispondenza");
            }
        }

        //2.Cerca per termine generale
        public static void cercaParola()
        {
            string stringa = "\n";

            Console.Write("\n        Inserire termine: ");
            string? ricerca = Console.ReadLine();

            foreach (Pubblicazione pubblicazione in Inventario)
            {
                if (pubblicazione.GetType() == typeof(Giornale))
                {
                    Giornale temp = (Giornale)pubblicazione;

                    if (ricerca is not null && temp.ToSearch().ToUpper().Trim().IndexOf(ricerca.ToUpper().Trim()) != -1)
                    {
                        stringa += temp.ToString() + "\n";
                    }
                }

                if (pubblicazione.GetType() == typeof(Rivista))
                {
                    Rivista temp = (Rivista)pubblicazione;

                    if (ricerca is not null && temp.ToSearch().ToUpper().Trim().IndexOf(ricerca.ToUpper().Trim()) != -1)
                    {
                        stringa += temp.ToString() + "\n";
                    }
                }
            }

            if (!stringa.Equals("\n"))
                Console.WriteLine(stringa);

            else
                Console.WriteLine("Nessuna corrispondenza");
        }

        //3.Visualizza elenco ordinato per stock
        public static void filtraPerStock()
        {
            List<Pubblicazione> pubblicaziones = Inventario.OrderBy(x => x.Stock).ToList();

            if (pubblicaziones.Count > 0)
            {
                string stringa = "\n";

                for (int i = pubblicaziones.Count - 1; i >= 0; i--)
                {
                    if (pubblicaziones[i].GetType() == typeof(Giornale))
                    {
                        Giornale temp = (Giornale)pubblicaziones[i];
                        stringa += temp.ToString() + "\n";
                    }

                    if (pubblicaziones[i].GetType() == typeof(Rivista))
                    {
                        Rivista temp = (Rivista)pubblicaziones[i];
                        stringa += temp.ToString() + "\n";
                    }
                }

                Console.WriteLine(stringa);
            }

            else
                Console.WriteLine("Inventario vuoto.");




        }

        #endregion Fine Menu 3

        #region Menu 4 - Gestione sottoscrizioni

        //1.Aggiungi sottoscrizione
        public static void aggiungiSottoscrizione()
        {
            Console.Write("\n        0.Torna indietro\n        1.Inserici nuovo cliente\n" +
                    "        2.Aggiungi sottoscrizione a cliente esistente\n");
            int? risposta = Convert.ToInt32((Console.ReadLine()));

            //Inserisci nuovo cliente
            if (risposta == 1)
            {
                try
                {
                    Console.Write("\n            Inserisci nome: ");
                    string? nome = Console.ReadLine();

                    Console.Write("\n            Inserisci cognome: ");
                    string? cognome = Console.ReadLine();

                    Clienti cliente = new Clienti();
                    cliente.Id = getUnusedIDClienti();
                    cliente.Nome = nome;
                    cliente.Cognome = cognome;

                    string stringa = stampaInventario();

                    if (!stringa.Equals("\nInventario vuoto"))
                    {
                        Console.WriteLine(stringa);

                        Console.Write("\n            Inserisci l'ID della pubblicazione a cui sottoscrive il cliente: ");
                        int? idRicevuto = Convert.ToInt32(Console.ReadLine());

                        foreach (Pubblicazione pubblicazione in Inventario)
                        {
                            if (pubblicazione.Id == idRicevuto)
                            {
                                cliente.ListaSottoscrizioni.Add(pubblicazione);
                                cliente.QuantitaSottoscrizioni += 1;
                                Console.WriteLine($"\nCliente aggiunto con successo");
                            }
                        }
                    }
                        
                    else
                        Console.WriteLine(stringa);

                    ListaClienti.Add(cliente);
                    overwrite(pathSottoscrizioni);
                }

                catch { Console.WriteLine("Qualcosa é andato storto."); }
            }

            //Aggiungi sottoscrizione a cliente esistente
            if (risposta == 2)
            {
                try
                {
                    string stringa = "\n";

                    foreach (Clienti cliente in ListaClienti)
                    {
                        stringa += cliente + "\n";
                    }

                    if (!stringa.Equals("\n"))
                    {
                        Console.WriteLine(stringa);

                        Console.Write("\n            Inserisci l'ID del cliente che vuole sottoscrivere: ");
                        int? idRicevuto = Convert.ToInt32(Console.ReadLine());

                        foreach (Clienti cliente in ListaClienti)
                        {
                            if (cliente.Id == idRicevuto)
                            {
                                string stringa2 = "\n";

                                foreach (Pubblicazione pub in Inventario)
                                {
                                    if (pub.GetType() == typeof(Giornale))
                                    {
                                        Giornale temp = (Giornale)pub;
                                        stringa2 += temp.ToString() + "\n";
                                    }
                                    if (pub.GetType() == typeof(Rivista))
                                    {
                                        Rivista temp = (Rivista)pub;
                                        stringa2 += temp.ToString() + "\n";
                                    }
                                }

                                if (!stringa2.Equals("\n"))
                                {
                                    Console.WriteLine(stringa2);

                                    Console.Write("\nInserire ID della pubblicazione a cui sottoscrivere: ");

                                    int? idRicevut = Convert.ToInt32(Console.ReadLine());

                                    foreach (Pubblicazione pubblicazione in Inventario)
                                    {
                                        if (pubblicazione.Id == idRicevut)
                                        {
                                            cliente.ListaSottoscrizioni.Add(pubblicazione);
                                            cliente.QuantitaSottoscrizioni += 1;
                                            overwrite(pathSottoscrizioni);
                                            Console.WriteLine($"\nCliente aggiunto con successo");
                                        }
                                    }
                                }

                                else
                                    Console.WriteLine($"\nInventario vuoto");
                            }
                        }
                    }

                    else
                        Console.WriteLine("La lista clienti é vuota");

                }
                catch { Console.WriteLine("Qualcosa é andato storto."); }
            }
        }   

        //1.Rimuovi sottoscrizione
        public static void rimuoviSottoscrizione()
        {
            string stringa = "\n";

            foreach (Clienti cliente in ListaClienti)
            {
                stringa += cliente + "\n";
            }

            if (!stringa.Equals("\n"))
            {
                Console.WriteLine(stringa);

                Console.Write("\n            Inserisci l'ID del cliente che vuole rimuovere la sottoscrizione: ");
                int? idRicevuto = Convert.ToInt32(Console.ReadLine());

                foreach (Clienti cliente in ListaClienti)
                {
                    if (cliente.Id == idRicevuto)
                    {
                        string stringa2 = "\n";

                        foreach (Pubblicazione pub in cliente.ListaSottoscrizioni)
                        {
                            if (pub.GetType() == typeof(Giornale))
                            {
                                Giornale temp = (Giornale)pub;
                                stringa2 += temp.ToString() + "\n";
                            }
                            if (pub.GetType() == typeof(Rivista))
                            {
                                Rivista temp = (Rivista)pub;
                                stringa2 += temp.ToString() + "\n";
                            }
                        }

                        if (!stringa2.Equals("\n"))
                        {
                            Console.WriteLine(stringa2);

                            Console.Write("\n            Inserisci l'ID della sottoscrizione da rimuovere: ");
                            int? idRicevut = Convert.ToInt32(Console.ReadLine());

                            foreach (Pubblicazione sottoscrizione in cliente.ListaSottoscrizioni)
                            {
                                if (sottoscrizione.Id == idRicevut)
                                {
                                    cliente.QuantitaSottoscrizioni -= 1;
                                    cliente.ListaSottoscrizioni.Remove(sottoscrizione);
                                    overwrite(pathSottoscrizioni);
                                    Console.Write("\n            Rimozione effettuata.");
                                }
                            }
                        }

                        else
                            Console.WriteLine("Il cliente non ha sottoscrizioni");
                    }
                }
            }

            else
                Console.WriteLine("La lista clienti é vuota");
        }

        //1.Visualizza programma sottoscrizoni
        public static void mostraSottoscrizioni()
        {
            string stringa = "\n";

            foreach (Clienti cliente in ListaClienti)
            {
                stringa += cliente + "\n";
            }

            if (stringa.Equals("\n"))
                Console.WriteLine("La lista clienti é vuota");

            else
                Console.WriteLine(stringa);
        }

        #endregion Fine Menu 4
    }
}