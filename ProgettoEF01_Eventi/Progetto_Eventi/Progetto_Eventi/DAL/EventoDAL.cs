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
                    Evento? risorsa = context.Eventos.Find(t.EventoId);

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
    }
}
