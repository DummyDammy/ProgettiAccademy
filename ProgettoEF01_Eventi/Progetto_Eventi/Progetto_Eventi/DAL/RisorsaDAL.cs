using Microsoft.EntityFrameworkCore;
using Progetto_Eventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Eventi.DAL
{
    internal class RisorsaDAL
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

            using (var context = new Progetto05EventiContext())
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
            using (var context = new Progetto05EventiContext())
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
            using (var context = new Progetto05EventiContext())
            {
                try
                {
                    return context.Risorsas.Include(r => r.Eventos).Single(r => r.RisorsaId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Risorsa();
        }

        public bool insert(Risorsa t)
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

        public bool update(Risorsa t)
        {
            bool controllo = false;

            using (var context = new Progetto05EventiContext())
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
    }
}
