using ProgettoWPF_Gestione_Abiti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoWPF_GestioneAbiti.DAL
{
    internal class OffertumDAL : IDal<Offertum>
    {
        #region Singleton
        static OffertumDAL? instance;

        public static OffertumDAL getInstance()
        {
            if (instance == null)
                instance = new OffertumDAL();

            return instance;
        }

        OffertumDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Offertum offerta = context.Offerta.Single(o => o.OffertaId == id);
                    context.Offerta.Remove(offerta);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Offertum> findAll()
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Offerta.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Offertum>();
        }

        public Offertum findById(int id)
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Offerta.Single(o => o.OffertaId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Offertum();
        }

        public bool insert(Offertum t)
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

        public bool update(Offertum t)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Offertum? offerta = context.Offerta.Find(t.OffertaId);

                    if (offerta == null)
                        return controllo;

                    context.Entry(offerta).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
