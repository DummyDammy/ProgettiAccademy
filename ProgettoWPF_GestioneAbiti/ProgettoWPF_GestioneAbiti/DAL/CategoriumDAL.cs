using ProgettoWPF_GestioneAbiti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoWPF_GestioneAbiti.DAL
{
    internal class CategoriumDAL : IDal<Categorium>
    {
        #region Singleton
        static CategoriumDAL? instance;

        public static CategoriumDAL getInstance()
        {
            if (instance == null)
                instance = new CategoriumDAL();

            return instance;
        }

        CategoriumDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Categorium categoria = context.Categoria.Single(c => c.CategoriaId == id);
                    context.Categoria.Remove(categoria);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Categorium> findAll()
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Categoria.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Categorium>();
        }

        public Categorium findById(int id)
        {
            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    return context.Categoria.Single(c => c.CategoriaId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Categorium();
        }

        public bool insert(Categorium t)
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

        public bool update(Categorium t)
        {
            bool controllo = false;

            using (var context = new Progetto06NegozioAbitiContext())
            {
                try
                {
                    Categorium? categoria = context.Categoria.Find(t.CategoriaId);

                    if (categoria == null)
                        return controllo;

                    context.Entry(categoria).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
