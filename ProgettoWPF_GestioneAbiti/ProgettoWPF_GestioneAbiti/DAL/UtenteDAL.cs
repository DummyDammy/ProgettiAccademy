using ProgettoWPF_GestioneAbiti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoWPF_GestioneAbiti.DAL
{
    internal class UtenteDAL : IDal<Utente>
    {

        #region Singleton
        static UtenteDAL? instance;

        public static UtenteDAL getInstance()
        {
            if (instance == null)
                instance = new UtenteDAL();

            return instance;
        }

        UtenteDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Utente utente = context.Utentes.Single(u => u.UtenteId == id);
                    context.Utentes.Remove(utente);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Utente> findAll()
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Utentes.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Utente>();
        }

        public Utente findById(int id)
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Utentes.Single(u => u.UtenteId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Utente();
        }

        public bool insert(Utente t)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
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

        public bool update(Utente t)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Utente? utente = context.Utentes.Find(t.UtenteId);

                    if (utente == null)
                        return controllo;

                    context.Entry(utente).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
