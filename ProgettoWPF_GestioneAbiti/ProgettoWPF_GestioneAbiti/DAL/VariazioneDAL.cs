using ProgettoWPF_GestioneAbiti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoWPF_GestioneAbiti.DAL
{
    internal class VariazioneDAL : IDal<Variazione>
    {
        #region Singleton
        static VariazioneDAL? instance;

        public static VariazioneDAL getInstance()
        {
            if (instance == null)
                instance = new VariazioneDAL();

            return instance;
        }

        VariazioneDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Variazione variazione = context.Variaziones.Single(v => v.VariazioneId == id);
                    context.Variaziones.Remove(variazione);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Variazione> findAll()
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Variaziones.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Variazione>();
        }

        public Variazione findById(int id)
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Variaziones.Single(v => v.VariazioneId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Variazione();
        }

        public bool insert(Variazione t)
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

        public bool update(Variazione t)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Variazione? variazione = context.Variaziones.Find(t.VariazioneId);

                    if (variazione == null)
                        return controllo;

                    context.Entry(variazione).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
