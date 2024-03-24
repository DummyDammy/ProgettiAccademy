using Microsoft.EntityFrameworkCore;
using Progetto_GestioneEventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_GestioneEventi.DAL
{
    internal class RisorsaDAL : IDal<Risorsa>
    {
        #region Singleton
        static RisorsaDAL? instance;

        public static RisorsaDAL getInstance()
        {
            if (instance == null)
                instance = new RisorsaDAL();

            return instance;
        }

        RisorsaDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Risorsa risorsa = context.Risorsas.Single(r => r.RisorsaId == id);
                    context.Risorsas.Remove(risorsa);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Risorsa> findAll()
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Risorsas.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Risorsa>();
        }

        public Risorsa findById(int id)
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Risorsas.Single(r => r.RisorsaId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new Risorsa();
        }

        public bool insert(Risorsa t)
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

        public bool update(Risorsa t)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Risorsa? risorsa = context.Risorsas.Find(t.RisorsaId);

                    if (risorsa == null)
                        return controllo;

                    context.Entry(risorsa).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public bool assignRisorsa(int id, Evento t)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Risorsa risorsa = context.Risorsas.Single(p => p.RisorsaId == id);
                    t.RisorsaRifs.Add(risorsa);
                    risorsa.EventoRifs.Add(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Risorsa> findAllgetEventi()
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Risorsas.Include(r => r.EventoRifs).ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Risorsa>();
        }

        public bool RemoveRisorsa(Evento evento, Risorsa risorsa)
        {
            bool controllo = false;

            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    Evento e = new Evento() { EventoId = evento.EventoId };
                    Risorsa r = new Risorsa() { RisorsaId = risorsa.RisorsaId };
                    e.RisorsaRifs.Add(r);
                    context.Eventos.Attach(e);
                    e.RisorsaRifs.Remove(r);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return controllo;
        }

        public Risorsa findByIDgetEventi(int id)
        {
            using (var context = new Progetto0502EventiContext())
            {
                try
                {
                    return context.Risorsas.Include(r => r.EventoRifs).Single(r => r.RisorsaId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Risorsa();
        }
    }
}
