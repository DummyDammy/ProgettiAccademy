using Progetto_Eventi.DAL;
using Progetto_Eventi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Eventi.Classes
{
    internal class Sottomenu
    {
        #region Singleton
        static Sottomenu? instance;

        public static Sottomenu getInstance()
        {
            if (instance == null)
                instance = new Sottomenu();

            return instance;
        }

        Sottomenu() { }
        #endregion

        #region Sottomenu 1.Gestione eventi
        public void AggiungiEvento()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Aggiungi evento");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    Console.Write("Inserire nome evento: ");
                    string? nome = Console.ReadLine();

                    #region controllo risposta nome
                    while (nome is null || nome.Trim().Equals(""))
                    {
                        Console.WriteLine("\nNome evento non valido");
                        Console.Write("\nInserire nome evento: ");
                        nome = Console.ReadLine();
                    }
                    #endregion

                    bool controllo = true;

                    while (controllo)
                    {
                        int check = EventoDAL.getInstance().findByNome(nome);

                        if (check > 0)
                        {
                            Console.WriteLine("\nNome evento già preso");
                            Console.Write("\nInserire nome evento: ");
                            nome = Console.ReadLine();
                        }
                        else
                            controllo = false;
                    }

                    Console.Write("Inserire giorno evento: ");
                    int giorno = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Inserire mese evento: ");
                    int mese = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Inserire anno evento: ");
                    int anno = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Inserire luogo evento: ");
                    string? luogo = Console.ReadLine();

                    #region controllo risposta luogo
                    while (luogo is null || luogo.Trim().Equals(""))
                    {
                        Console.WriteLine("\nLuogo evento non valido");
                        Console.Write("\nInserire luogo evento: ");
                        luogo = Console.ReadLine();
                    }
                    #endregion

                    Console.Write("Inserire capacità evento: ");
                    int capacita = Convert.ToInt32(Console.ReadLine());

                    EventoDAL.getInstance().insert(new Evento() { Nome = nome, DataEvento = new DateOnly(anno, mese, giorno), Luogo = luogo, Capacita = capacita });
                    Console.WriteLine("\nEvento inserito");
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public void RimuoviEventoById()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Rimuovi evento");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string eventi = EventiToList();

                    Console.WriteLine(eventi);

                    if (!eventi.Equals("Nessun evento trovato"))
                    {
                        Console.Write("\nInserire ID dell'evento da rimuovere: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        bool controllo = EventoDAL.getInstance().deleteById(id);

                        if (controllo)
                            Console.WriteLine("\nEvento rimosso");
                        else
                            Console.WriteLine("\nEvento non trovato");
                    }
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public void AggiornaEventoById()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Modifica evento");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string eventi = EventiToList();

                    Console.WriteLine(eventi);

                    if (!eventi.Equals("Nessun evento trovato"))
                    {
                        Console.Write("\nInserire ID dell'evento da modificare: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Evento evento = EventoDAL.getInstance().findById(id);

                        if (evento != new Evento())
                        {
                            Console.Write("Inserire nome evento: ");
                            string? nome = Console.ReadLine();

                            #region controllo risposta nome
                            while (nome is null || nome.Trim().Equals(""))
                            {
                                Console.WriteLine("\nNome evento non valido");
                                Console.Write("\nInserire nome evento: ");
                                nome = Console.ReadLine();
                            }
                            #endregion

                            Console.Write("Inserire giorno evento: ");
                            int giorno = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Inserire mese evento: ");
                            int mese = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Inserire anno evento: ");
                            int anno = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Inserire luogo evento: ");
                            string? luogo = Console.ReadLine();

                            #region controllo risposta luogo
                            while (luogo is null || luogo.Trim().Equals(""))
                            {
                                Console.WriteLine("\nLuogo evento non valido");
                                Console.Write("\nInserire luogo evento: ");
                                luogo = Console.ReadLine();
                            }
                            #endregion

                            Console.Write("Inserire capacità evento: ");
                            int capacita = Convert.ToInt32(Console.ReadLine());

                            EventoDAL.getInstance().update(new Evento() { EventoId = evento.EventoId, Nome = nome, DataEvento = new DateOnly(anno, mese, giorno), Luogo = luogo, Capacita = capacita });
                            Console.WriteLine("\nEvento modificato");
                        }

                        else
                            Console.WriteLine("\nEvento non trovato");
                    }
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public string EventiToList()
        {
            ICollection<Evento>? eventi = EventoDAL.getInstance().findAll();

            string stringa = "\n";

            if (eventi is not null)
            {
                foreach (Evento evento in eventi)
                {
                    if (!stringa.Contains($"Nome:{evento.Nome} |"))
                        stringa += $"Id:{evento.EventoId} | Nome:{evento.Nome} | Data:{evento.DataEvento} | Luogo:{evento.Luogo} | Capacità:{evento.Capacita}\n";
                }
            }

            if (!stringa.Equals("\n"))
                return stringa;

            else
                return "Nessun evento trovato";
        }

        public string MostraPartecipantiEventi()
        {
            string stringa = "\n";
            ICollection<Evento> eventi = EventoDAL.getInstance().findAll();

            foreach (Evento evento in eventi)
            {
                if (evento.PartecipanteRif is not null)
                {
                    if (!stringa.Contains($"{evento.Nome} |"))
                        stringa += evento.Nome + " |\n";

                    ICollection<Partecipante> partecipanti = PartecipanteDAL.getInstance().findAllByEvento(evento);

                    foreach (Partecipante partecipante in partecipanti)
                    {
                        stringa += $"    Id:{partecipante.PartecipanteId} | Nome:{partecipante.Nome} | Cognome:{partecipante.Cognome} | Email:{partecipante.Email}\n";
                    }
                }
            }
            return stringa;
        }

        public string MostraRisorseEventi()
        {
            string stringa = "\n";
            ICollection<Evento> eventi = EventoDAL.getInstance().findAll();

            foreach (Evento evento in eventi)
            {
                if (evento.RisorsaRif is not null)
                {
                    if (!stringa.Contains($"{evento.Nome} |"))
                        stringa += evento.Nome + " |\n";

                    ICollection<Risorsa> risorse = RisorsaDAL.getInstance().findAllByEvento(evento);

                    foreach (Risorsa risorsa in risorse)
                    {
                        stringa += $"    Id:{risorsa.RisorsaId} | Tipo:{risorsa.Tipo} | Nome:{risorsa.Nome} | Quantità:{risorsa.Quantita} | Prezzo:{risorsa.Prezzo} | Fornitore:{risorsa.Fornitore}\n";
                    }
                }
            }
            return stringa;
        }
        #endregion

        #region Sottomenu 2.Gestione partecipanti
        public void AggiungiPartecipante()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Aggiungi partecipante");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    Console.Write("Inserire nome partecipante: ");
                    string? nome = Console.ReadLine();

                    #region controllo risposta nome
                    while (nome is null || nome.Trim().Equals(""))
                    {
                        Console.WriteLine("\nNome partecipante non valido");
                        Console.Write("\nInserire nome partecipante: ");
                        nome = Console.ReadLine();
                    }
                    #endregion

                    Console.Write("Inserire cognome partecipante: ");
                    string? cognome = Console.ReadLine();

                    #region controllo risposta nome
                    while (cognome is null || cognome.Trim().Equals(""))
                    {
                        Console.WriteLine("\nCognome partecipante non valido");
                        Console.Write("\nInserire cognome partecipante: ");
                        cognome = Console.ReadLine();
                    }
                    #endregion

                    Console.Write("Inserire email del partecipante: ");
                    string? email = Console.ReadLine();

                    #region controllo risposta luogo
                    while (email is null || email.Trim().Equals(""))
                    {
                        Console.WriteLine("\nEmail non valida");
                        Console.Write("\nInserire email del patecipante: ");
                        email = Console.ReadLine();
                    }
                    #endregion

                    PartecipanteDAL.getInstance().insert(new Partecipante() { Nome = nome, Cognome = cognome, Email = email });
                    Console.WriteLine("\nPartecipante inserito");
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public void RimuovePartecipanteById()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Rimuovi partecipante");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string partecipanti = PartecipantiToList();

                    Console.WriteLine(partecipanti);

                    if (!partecipanti.Equals("Nessun evento trovato"))
                    {
                        Console.Write("\nInserire ID del partecipante da rimuovere: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        bool controllo = PartecipanteDAL.getInstance().deleteById(id);

                        if (controllo)
                            Console.WriteLine("\nEvento rimosso");
                        else
                            Console.WriteLine("\nEvento non trovato");
                    }
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public void AssegnarePartecipante()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Assegna partecipante");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string partecipanti = PartecipantiToList();

                    Console.WriteLine(partecipanti);

                    if (!partecipanti.Equals("Nessun partecipante trovato"))
                    {
                        Console.Write("\nInserire ID del partecipante da assegnare: ");
                        int idPartecipante = Convert.ToInt32(Console.ReadLine());

                        string eventi = EventiToList();

                        Console.WriteLine(eventi);

                        if (!eventi.Equals("Nessun evento trovato"))
                        {
                            Console.Write("\nInserire ID dell'evento a cui assegnare: ");
                            int idEvento = Convert.ToInt32(Console.ReadLine());

                            Evento evento = EventoDAL.getInstance().findById(idEvento);

                            PartecipanteDAL.getInstance().assignPartecipante(idPartecipante, evento);
                        }
                    }
                }
            }
            catch { Console.WriteLine("Qualcosa è andato storto"); }
        }

        public void RimuovePartecipanteDaEvento()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Rimuovi partecipante da evento");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string partecipanti = PartecipantiToList();

                    Console.WriteLine(partecipanti);

                    if (!partecipanti.Equals("Nessun partecipante trovato"))
                    {
                        Console.Write("\nInserire ID del partecipante: ");
                        int idPartecipante = Convert.ToInt32(Console.ReadLine());

                        Partecipante partecipante = PartecipanteDAL.getInstance().findById(idPartecipante);

                        if (partecipante.Eventos != new List<Evento>())
                        {
                            Console.WriteLine();
                            foreach(Evento evento in partecipante.Eventos)
                            {
                                Console.Write($"Id:{evento.EventoId} | Nome:{evento.Nome} | Data:{evento.DataEvento} | Luogo:{evento.Luogo} | Capacità:{evento.Capacita}\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nessun evento trovato");
                            return;
                        }

                        Console.Write("\nInserire ID dell'evento: ");
                        int idEvento = Convert.ToInt32(Console.ReadLine());

                        Evento e = EventoDAL.getInstance().findById(idEvento);

                        EventoDAL.getInstance().RemovePartecipante(e, idPartecipante);
                    }
                }
            }
            catch { Console.WriteLine("Qualcosa è andato storto."); }
        }

        public string PartecipantiToList()
        {
            ICollection<Partecipante>? partecipanti = PartecipanteDAL.getInstance().findAll();

            string stringa = "\n";

            if (partecipanti is not null)
            {
                foreach (Partecipante partecipante in partecipanti)
                {
                    stringa += $"Id:{partecipante.PartecipanteId} | Nome:{partecipante.Nome} | Cognome:{partecipante.Cognome} | Email:{partecipante.Email}\n";
                }
            }

            if (!stringa.Equals("\n"))
                return stringa;

            else
                return "Nessun partecipante trovato";
        }

        public string MostraEventiPartecipanti()
        {
            string stringa = "\n";
            ICollection<Partecipante> partecipanti = PartecipanteDAL.getInstance().findAllWithEventi();
            
            foreach (Partecipante partecipante in partecipanti)
            {
                stringa += partecipante.Nome + " " + partecipante.Cognome + " |\n";

                foreach (Evento evento in partecipante.Eventos)
                {
                    stringa += $"    Id:{evento.EventoId} | Nome:{evento.Nome} | Data:{evento.DataEvento}\n";
                }
            }
            return stringa;
        }

        public void AggiornaPartecipanteById()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Modifica dati partecipante");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string partecipanti = PartecipantiToList();

                    Console.WriteLine(partecipanti);

                    if (!partecipanti.Equals("Nessun evento trovato"))
                    {
                        Console.Write("\nInserire ID del partecipante da modificare: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Partecipante partecipante = PartecipanteDAL.getInstance().findById(id);

                        if (partecipante != new Partecipante())
                        {
                            Console.Write("Inserire nome partecipante: ");
                            string? nome = Console.ReadLine();

                            #region controllo risposta nome
                            while (nome is null || nome.Trim().Equals(""))
                            {
                                Console.WriteLine("\nNome partecipante non valido");
                                Console.Write("\nInserire nome partecipante: ");
                                nome = Console.ReadLine();
                            }
                            #endregion

                            Console.Write("Inserire cognome partecipante: ");
                            string? cognome = Console.ReadLine();

                            #region controllo risposta nome
                            while (cognome is null || cognome.Trim().Equals(""))
                            {
                                Console.WriteLine("\nCognome partecipante non valido");
                                Console.Write("\nInserire cognome partecipante: ");
                                cognome = Console.ReadLine();
                            }
                            #endregion

                            Console.Write("Inserire email del partecipante: ");
                            string? email = Console.ReadLine();

                            #region controllo risposta luogo
                            while (email is null || email.Trim().Equals(""))
                            {
                                Console.WriteLine("\nEmail non valida");
                                Console.Write("\nInserire email del patecipante: ");
                                email = Console.ReadLine();
                            }
                            #endregion

                            PartecipanteDAL.getInstance().update(new Partecipante() {PartecipanteId = partecipante.PartecipanteId, Nome = nome, Cognome = cognome, Email = email });
                            Console.WriteLine("\nPartecipante modificato");
                        }

                        else
                            Console.WriteLine("\nPartecipante non trovato");
                    }
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }
        #endregion

        #region Sottomenu 3.Gestione risorse
        public void AggiungiRisorsa()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Aggiungi risorsa");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    Console.Write("Inserire tipo risorsa: ");
                    string? tipo = Console.ReadLine();

                    #region controllo risposta nome
                    while (tipo is null || tipo.Trim().Equals(""))
                    {
                        Console.WriteLine("\nTipo risorsa non valido");
                        Console.Write("\nInserire tipo risorsa: ");
                        tipo = Console.ReadLine();
                    }
                    #endregion

                    Console.Write("Inserire nome risorsa: ");
                    string? nome = Console.ReadLine();

                    #region controllo risposta nome
                    while (nome is null || nome.Trim().Equals(""))
                    {
                        Console.WriteLine("\nNome risorsa non valido");
                        Console.Write("\nInserire nome risorsa: ");
                        nome = Console.ReadLine();
                    }
                    #endregion

                    Console.Write("Inserire quantità: ");
                    int quantita = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Inserire prezzo: ");
                    decimal prezzo = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Inserire fornitore della risorsa: ");
                    string? fornitore = Console.ReadLine();

                    #region controllo risposta nome
                    while (fornitore is null || fornitore.Trim().Equals(""))
                    {
                        Console.WriteLine("\nFornitore non valido");
                        Console.Write("\nInserire fornitore della risorsa: ");
                        fornitore = Console.ReadLine();
                    }
                    #endregion

                    RisorsaDAL.getInstance().insert(new Risorsa() { Tipo = tipo, Nome = nome, Quantita = quantita, Prezzo = prezzo, Fornitore = fornitore });
                    Console.WriteLine("\nRisorsa inserita");
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public void RimuoviRisorsaById()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Rimuovi risorsa");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string risorse = RisorseToList();

                    Console.WriteLine(risorse);

                    if (!risorse.Equals("Nessuna risorsa trovato"))
                    {
                        Console.Write("\nInserire ID della risorsa da rimuovere: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        bool controllo = RisorsaDAL.getInstance().deleteById(id);

                        if (controllo)
                            Console.WriteLine("\nRisorsa rimossa");
                        else
                            Console.WriteLine("\nRisorsa non trovata");
                    }
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public void ModificaRisorsaById()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Modifica dati risorsa");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string risorse = RisorseToList();

                    Console.WriteLine(risorse);

                    if (!risorse.Equals("Nessuna risorsa trovata"))
                    {
                        Console.Write("\nInserire ID della risorsa da modificare: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Risorsa risorsa = RisorsaDAL.getInstance().findById(id);

                        if (risorsa != new Risorsa())
                        {
                            Console.Write("Inserire tipo risorsa: ");
                            string? tipo = Console.ReadLine();

                            #region controllo risposta nome
                            while (tipo is null || tipo.Trim().Equals(""))
                            {
                                Console.WriteLine("\nTipo risorsa non valido");
                                Console.Write("\nInserire tipo risorsa: ");
                                tipo = Console.ReadLine();
                            }
                            #endregion

                            Console.Write("Inserire nome risorsa: ");
                            string? nome = Console.ReadLine();

                            #region controllo risposta nome
                            while (nome is null || nome.Trim().Equals(""))
                            {
                                Console.WriteLine("\nNome risorsa non valido");
                                Console.Write("\nInserire nome risorsa: ");
                                nome = Console.ReadLine();
                            }
                            #endregion

                            Console.Write("Inserire quantità: ");
                            int quantita = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Inserire prezzo: ");
                            decimal prezzo = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Inserire fornitore della risorsa: ");
                            string? fornitore = Console.ReadLine();

                            #region controllo risposta nome
                            while (fornitore is null || fornitore.Trim().Equals(""))
                            {
                                Console.WriteLine("\nFornitore non valido");
                                Console.Write("\nInserire fornitore della risorsa: ");
                                fornitore = Console.ReadLine();
                            }
                            #endregion

                            RisorsaDAL.getInstance().update(new Risorsa() {RisorsaId = risorsa.RisorsaId, Tipo = tipo, Nome = nome, Quantita = quantita, Prezzo = prezzo, Fornitore = fornitore });
                            Console.WriteLine("\nRisorsa modificata");
                        }

                        else
                            Console.WriteLine("\nRisorsa non trovata");
                    }
                }
            }
            catch { Console.WriteLine("\nQualcosa è andato storto"); }
        }

        public void AssegnaRisorsa()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Assegna risorsa");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string risorse = RisorseToList();

                    Console.WriteLine(risorse);

                    if (!risorse.Equals("Nessuna risorsa trovata"))
                    {
                        Console.Write("\nInserire ID della risorsa da assegnare: ");
                        int idRisorsa = Convert.ToInt32(Console.ReadLine());

                        string eventi = EventiToList();

                        Console.WriteLine(eventi);

                        if (!eventi.Equals("Nessun evento trovato"))
                        {
                            Console.Write("\nInserire ID dell'evento a cui assegnare: ");
                            int idEvento = Convert.ToInt32(Console.ReadLine());

                            Evento evento = EventoDAL.getInstance().findById(idEvento);

                            RisorsaDAL.getInstance().assignRisorsa(idRisorsa, evento);
                        }
                    }
                }
            }
            catch { Console.WriteLine("Qualcosa è andato storto"); }
        }

        public string RisorseToList()
        {
            ICollection<Risorsa>? risorse = RisorsaDAL.getInstance().findAll();

            string stringa = "\n";

            if (risorse is not null)
            {
                foreach (Risorsa risorsa in risorse)
                {
                    stringa += $"Id:{risorsa.RisorsaId} | Tipo:{risorsa.Tipo} | Nome:{risorsa.Nome} | Quantità:{risorsa.Quantita} | Prezzo:{risorsa.Prezzo} | Fornitore:{risorsa.Fornitore}\n";
                }
            }

            if (!stringa.Equals("\n"))
                return stringa;

            else
                return "Nessuna risorsa trovata";
        }

        public string MostraEventiRisorse()
        {
            string stringa = "\n";
            ICollection<Risorsa> risorse = RisorsaDAL.getInstance().findAllWithEventi();

            foreach (Risorsa risorsa in risorse)
            {
                stringa += risorsa.Nome + " " + risorsa.Fornitore + " |\n";

                foreach (Evento evento in risorsa.Eventos)
                {
                    stringa += $"    Id:{evento.EventoId} | Nome:{evento.Nome} | Data:{evento.DataEvento}\n";
                }
            }
            return stringa;
        }

        public void RimuoviRisorsaDaEvento()
        {
            try
            {
                Console.WriteLine("        0.Torna indietro\n        1.Rimuovi risorsa da evento");
                int? risposta = Convert.ToInt32(Console.ReadLine());

                #region controllo risposta
                while (risposta == null || risposta < 0 || risposta > 1)
                {
                    Console.Write("\nValore non valido. Inserire nuovo valore: ");
                    risposta = Convert.ToInt32((Console.ReadLine()));
                }
                #endregion

                if (risposta == 1)
                {
                    string risorse = RisorseToList();

                    Console.WriteLine(risorse);

                    if (!risorse.Equals("Nessuna risorsa trovata"))
                    {
                        Console.Write("\nInserire ID della risorsa: ");
                        int idRisorsa = Convert.ToInt32(Console.ReadLine());

                        Risorsa risorsa = RisorsaDAL.getInstance().findById(idRisorsa);

                        if (risorsa.Eventos != new List<Evento>())
                        {
                            Console.WriteLine();
                            foreach (Evento evento in risorsa.Eventos)
                            {
                                Console.Write($"Id:{evento.EventoId} | Nome:{evento.Nome} | Data:{evento.DataEvento} | Luogo:{evento.Luogo} | Capacità:{evento.Capacita}\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nessun evento trovato");
                            return;
                        }

                        Console.Write("\nInserire ID dell'evento: ");
                        int idEvento = Convert.ToInt32(Console.ReadLine());

                        Evento e = EventoDAL.getInstance().findById(idEvento);

                        EventoDAL.getInstance().RemoveRisorsa(e, idRisorsa);
                    }
                }
            }
            catch { Console.WriteLine("Qualcosa è andato storto"); }
        }
        #endregion
    }
}

