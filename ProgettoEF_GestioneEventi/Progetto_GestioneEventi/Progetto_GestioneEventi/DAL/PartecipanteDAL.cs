using Microsoft.EntityFrameworkCore;
using Progetto_GestioneEventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_GestioneEventi.DAL
{
    internal class PartecipanteDAL : IDal<Partecipante>
    {
        #region Singleton
        static PartecipanteDAL? instance;

        public static PartecipanteDAL getInstance()
        {
            if (instance == null)
                instance = new PartecipanteDAL();

            return instance;
        }

        PartecipanteDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Partecipante partecipante = context.Partecipantes.Single(p => p.PartecipanteId == id);
                    context.Partecipantes.Remove(partecipante);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Partecipante> findAll()
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Partecipantes.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Partecipante>();
        }

        public Partecipante findById(int id)
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Partecipantes.Single(p => p.PartecipanteId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Partecipante();
        }

        public Partecipante findByIDgetEventi(int id)
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Partecipantes.Include(p => p.EventoRifs).Single(p => p.PartecipanteId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Partecipante();
        }

        public bool insert(Partecipante t)
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

        public bool update(Partecipante t)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Partecipante? partecipante = context.Partecipantes.Find(t.PartecipanteId);

                    if (partecipante == null)
                        return controllo;

                    context.Entry(partecipante).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public bool assignPartecipante(int id, Evento t)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Partecipante partecipante = context.Partecipantes.Single(p => p.PartecipanteId == id);
                    t.PartecipanteRifs.Add(partecipante);
                    partecipante.EventoRifs.Add(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public bool RemovePartecipante(Evento evento, Partecipante partecipante)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Evento e = new Evento() { EventoId = evento.EventoId };
                    Partecipante p = new Partecipante() { PartecipanteId = partecipante.PartecipanteId };
                    e.PartecipanteRifs.Add(p);
                    context.Eventos.Attach(e);
                    e.PartecipanteRifs.Remove(p);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return controllo;
        }

        public List<Partecipante> findAllgetEventi()
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Partecipantes.Include(p => p.EventoRifs).ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Partecipante>();
        }
    }
}
