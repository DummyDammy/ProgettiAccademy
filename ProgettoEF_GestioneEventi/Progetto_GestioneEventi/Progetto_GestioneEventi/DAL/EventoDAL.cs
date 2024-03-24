using Microsoft.EntityFrameworkCore;
using Progetto_GestioneEventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_GestioneEventi.DAL
{
    internal class EventoDAL : IDal<Evento>
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

            using (var context = new Progetto0502EventiContext())
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
            using (var context = new Progetto0502EventiContext())
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
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Eventos.Single(e => e.EventoId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Evento();
        }

        public Evento findByIDgetPartecipanti(int id)
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Eventos.Include(e => e.PartecipanteRifs).Single(e => e.EventoId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Evento();
        }

        public bool insert(Evento t)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
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

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Evento? evento = context.Eventos.Find(t.EventoId);

                    if (evento == null)
                        return controllo;

                    context.Entry(evento).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Evento> findAllgetPartecipanti()
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Eventos.Include(e => e.PartecipanteRifs).ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Evento>();
        }

        public List<Evento> findAllgetRisorse()
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Eventos.Include(e => e.RisorsaRifs).ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Evento>();
        }

        public List<Evento> findAllgetAll()
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Eventos.Include(e => e.PartecipanteRifs).Include(e => e.RisorsaRifs).ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Evento>();
        }
    }
}
