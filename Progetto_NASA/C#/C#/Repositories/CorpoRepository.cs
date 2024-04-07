using C_.Models;
using Microsoft.EntityFrameworkCore;

namespace C_.Repositories
{
    public class CorpoRepository : IRepository<Corpo>
    {
        #region context
        readonly NASAContext context;


        public CorpoRepository(NASAContext context)
        {
            this.context = context;
        }
        #endregion

        #region Implementazione interfaccia
        public bool DeleteByID(int id)
        {
            try
            {
                context.Remove(context.Corpi.Single(c => c.CorpoID == id));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<Corpo> GetAll()
        {
            try
            {
                return context.Corpi.ToList();
            }
            catch { }

            return new List<Corpo>();
        }

        public Corpo? GetByID(int id)
        {
            try
            {
                return context.Corpi.SingleOrDefault(c => c.CorpoID == id);
            }
            catch { }

            return null;
        }

        public bool Insert(Corpo t)
        {
            try
            {
                context.Corpi.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Corpo t)
        {
            try
            {
                context.Corpi.Update(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        public Corpo GetByCodice(string codice)
        {
            try
            {
                return context.Corpi.Single(c => c.Codice == codice);
            }
            catch { }

            return new Corpo();
        }

        public List<Corpo> GetAllGetSystems()
        {
            try
            {
                return context.Corpi.Include(c => c.ListaSistemi).ToList();
            }
            catch { }

            return new List<Corpo>();
        }

        public bool assignCorpo(Corpo corpo, string sistemaCodice)
        {
            try
            {
                Sistema sistema = context.Sistemi.Single(s => s.Codice == sistemaCodice);
                sistema.ListaCorpi.Add(corpo);
                corpo.ListaSistemi.Add(sistema);
                context.SaveChanges();
                return true;
            }
            catch { }
            return false;
        }

        public bool removeSistemaFromCorpo(string codiceCorpo, string codiceSistema)
        {
            try
            {
                Sistema sistema = context.Sistemi.Single(s => s.Codice == codiceSistema);
                Corpo corpo = context.Corpi.Include(s => s.ListaSistemi).Single(c => c.Codice == codiceCorpo);

                if (!corpo.ListaSistemi.Contains(sistema))
                    return false;

                corpo.ListaSistemi.Remove(sistema);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
    }
}
