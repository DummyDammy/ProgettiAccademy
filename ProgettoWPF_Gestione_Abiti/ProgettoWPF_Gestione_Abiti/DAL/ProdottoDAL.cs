using Microsoft.EntityFrameworkCore;
using ProgettoWPF_Gestione_Abiti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoWPF_GestioneAbiti.DAL
{
    internal class ProdottoDAL : IDal<Prodotto>
    {
        #region Singleton
        static ProdottoDAL? instance;

        public static ProdottoDAL getInstance()
        {
            if (instance == null)
                instance = new ProdottoDAL();

            return instance;
        }

        ProdottoDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Prodotto prodotto = context.Prodottos.Single(p => p.ProdottoId == id);
                    context.Prodottos.Remove(prodotto);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Prodotto> findAll()
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Prodottos.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Prodotto>();
        }

        public Prodotto findById(int id)
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Prodottos.Single(p => p.ProdottoId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Prodotto();
        }

        public bool insert(Prodotto t)
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

        public bool update(Prodotto t)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Prodotto? prodotto = context.Prodottos.Find(t.ProdottoId);

                    if (prodotto == null)
                        return controllo;

                    context.Entry(prodotto).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Prodotto> findAllGetCategoria()
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Prodottos.Include(p => p.CategoriaRifNavigation).ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Prodotto>();
        }
    }
}
