using Progetto_Eventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Eventi.DAL
{
    internal class EventoDAL
    {
        #region Singleton
        static EventoDAL? instance;

        public static EventoDAL getInstance()
        {
            if (instance == null)
                instance = new EventoDAL();

            return instance;
        }

        EventoDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    Evento evento = context.Eventos.Single(e => e.EventoId == id);
                    context.Eventos.Remove(evento);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Evento> findAll()
        {
            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    return context.Eventos.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Evento>();
        }

        public Evento findById(int id)
        {
            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    return context.Eventos.Single(e => e.EventoId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Evento();
        }

        public bool insert(Evento t)
        {
            bool controllo = false;

            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    context.Add(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public bool update(Evento t)
        {
            bool controllo = false;

            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    ICollection<Evento>? eventi = context.Eventos.Where(e => e.Nome == t.Nome).ToList();

                    if (eventi.Count() == 0)
                        return controllo;

                    foreach(Evento evento in eventi)
                    {
                        context.Eventos.Update();
                    }

                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public int findByNome(string nome)
        {
            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    return context.Eventos.Where(e => e.Nome == nome).ToList().Count();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return 0;
        }

        public bool RemovePartecipante(Evento evento, int idPartecipante)
        {
            bool controllo = false;

            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    Evento e = context.Eventos.Single(e => e.Nome == evento.Nome && e.PartecipanteRif == idPartecipante);
                    context.Eventos.Remove(e);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return controllo;
        }

        public bool RemoveRisorsa(Evento evento, int idRisorsa)
        {
            bool controllo = false;

            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    Evento e = context.Eventos.Single(e => e.Nome == evento.Nome && e.RisorsaRif == idRisorsa);
                    context.Eventos.Remove(e);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return controllo;
        }
    }
}
