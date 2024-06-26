﻿using Progetto_GestioneEventi.Classes;
using System.IO;

namespace Progetto_GestioneEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? risposta = 0;
            int? rispostaSottoMenu;

            do
            {
                try
                {
                    Console.WriteLine("\n0.Esci\n1.Gestione eventi\n2.Gestione partecipanti\n" +
                            "3.Gestione risorse\n");
                    risposta = Convert.ToInt32((Console.ReadLine()));

                    #region controllo risposta
                    while (risposta == null || risposta < 0 || risposta > 3)
                    {
                        Console.Write("\nValore non valido. Inserire nuovo valore: ");
                        risposta = Convert.ToInt32((Console.ReadLine()));
                    }
                    #endregion

                    #region 1.Gestione eventi
                    while (risposta == 1)
                    {
                        Console.WriteLine("\n    0.Torna indietro\n    1.Aggiungi evento\n" +
                                "    2.Rimuovi evento\n    3.Aggiorna evento\n" +
                                "    4.Mostra eventi\n    5.Mostra gli eventi e i suoi partecipanti\n    " +
                                "6.Mostra gli eventi e le risorse");
                        rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));

                        #region controllo risposta
                        while (risposta == null || risposta < 0 || risposta > 5)
                        {
                            Console.Write("\nValore non valido. Inserire nuovo valore: ");
                            risposta = Convert.ToInt32((Console.ReadLine()));
                        }
                        #endregion

                        if (rispostaSottoMenu == 0)
                            break;

                        switch (rispostaSottoMenu)
                        {
                            //1.Aggiungi evento
                            case 1:
                                Sottomenu.getInstance().AggiungiEvento();
                                break;

                            //2.Rimuovi evento
                            case 2:
                                Sottomenu.getInstance().RimuoviEventoById();
                                break;

                            //3.Aggiorna evento
                            case 3:
                                Sottomenu.getInstance().AggiornaEventoById();
                                break;

                            //4.Mostra eventi
                            case 4:
                                Console.WriteLine(Sottomenu.getInstance().EventiToList());
                                break;

                            //5.Mostra gli eventi e i suoi partecipanti
                            case 5:
                                Console.WriteLine(Sottomenu.getInstance().MostraPartecipantiEventi());
                                break;

                            //6.Mostra gli eventi e le risorse
                            case 6:
                                Console.WriteLine(Sottomenu.getInstance().MostraRisorseEventi());
                                break;
                        }
                    }
                    #endregion

                    #region 2.Gestione partecipanti
                    while (risposta == 2)
                    {
                        Console.WriteLine("\n    0.Torna indietro\n    1.Aggiungi partecipante\n" +
                                "    2.Rimuovi partecipante\n    3.Assegna partecipante ad evento\n    " +
                                "4.Rimuovi partecipante da evento\n" +
                                "    5.Mostra lista di tutti i partecipanti per tutti gli eventi\n    " +
                                "6.Mostra gli eventi e i suoi partecipanti\n    7.Modifica partecipante per ID");
                        rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));

                        #region controllo risposta
                        while (risposta == null || risposta < 0 || risposta > 6)
                        {
                            Console.Write("\nValore non valido. Inserire nuovo valore: ");
                            risposta = Convert.ToInt32((Console.ReadLine()));
                        }
                        #endregion

                        if (rispostaSottoMenu == 0)
                            break;

                        switch (rispostaSottoMenu)
                        {
                            //1.Aggiungi partecipante
                            case 1:
                                Sottomenu.getInstance().AggiungiPartecipante();
                                break;

                            //2.Rimuovi partecipante
                            case 2:
                                Sottomenu.getInstance().RimuovePartecipanteById();
                                break;

                            //3.Assegna partecipante ad evento
                            case 3:
                                Sottomenu.getInstance().AssegnarePartecipante();
                                break;

                            //4.Rimuovi partecipante da evento
                            case 4:
                                Sottomenu.getInstance().RimuovePartecipanteDaEvento();
                                break;

                            //5.Mostra lista di tutti i partecipanti per tutti gli eventi
                            case 5:
                                Console.WriteLine(Sottomenu.getInstance().PartecipantiToList());
                                break;

                            //6.Mostra gli eventi e i suoi partecipanti
                            case 6:
                                Console.WriteLine(Sottomenu.getInstance().MostraEventiPartecipanti());
                                break;

                            //7.Modifica partecipante per ID
                            case 7:
                                Sottomenu.getInstance().AggiornaPartecipanteById();
                                break;
                        }
                    }
                    #endregion

                    #region 3.Gestione risorse
                    while (risposta == 3)
                    {
                        Console.WriteLine("\n    0.Torna indietro\n    1.Aggiungi risorsa\n" +
                                "    2.Rimuovi risorsa\n    3.Modifica risorsa per id\n" +
                                "    4.Assegna risorsa ad evento\n    5.Mostra tutte le risorse\n    " +
                                "6.Mostra gli eventi e le risorse\n    7.Rimuovi risorsa da evento");
                        rispostaSottoMenu = Convert.ToInt32((Console.ReadLine()));

                        #region controllo risposta
                        while (risposta == null || risposta < 0 || risposta > 6)
                        {
                            Console.Write("\nValore non valido. Inserire nuovo valore: ");
                            risposta = Convert.ToInt32((Console.ReadLine()));
                        }
                        #endregion

                        if (rispostaSottoMenu == 0)
                            break;

                        switch (rispostaSottoMenu)
                        {
                            //1.Aggiungi risorsa
                            case 1:
                                Sottomenu.getInstance().AggiungiRisorsa();
                                break;

                            //2.Rimuovi risorsa
                            case 2:
                                Sottomenu.getInstance().RimuoviRisorsaById();
                                break;

                            //3.Modifica risorsa per id
                            case 3:
                                Sottomenu.getInstance().ModificaRisorsaById();
                                break;

                            //4.Assegna risorsa ad evento
                            case 4:
                                Sottomenu.getInstance().AssegnaRisorsa();
                                break;

                            //5.Mostra tutte le risorse
                            case 5:
                                Console.WriteLine(Sottomenu.getInstance().RisorseToList());
                                break;

                            //6.Mostra gli eventi e le risorse
                            case 6:
                                Console.WriteLine(Sottomenu.getInstance().MostraEventiRisorse());
                                break;

                            //7.Rimuovi risorsa da evento
                            case 7:
                                Sottomenu.getInstance().RimuoviRisorsaDaEvento();
                                break;
                        }
                    }
                    #endregion
                }
                catch { }

            } while (risposta != 0);

            Sottomenu.getInstance().saveCSV();
        }
    }
}
