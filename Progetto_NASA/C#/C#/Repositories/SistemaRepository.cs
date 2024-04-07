using C_.Models;
using Microsoft.EntityFrameworkCore;

namespace C_.Repositories
{
    public class SistemaRepository : IRepository<Sistema>
    {
        #region context
        readonly NASAContext context;

        public SistemaRepository(NASAContext context)
        {
            this.context = context;
        }
        #endregion

        #region Implementazione interfaccia
        public bool DeleteByID(int id)
        {
            try
            {
                context.Remove(context.Sistemi.Single(s => s.SistemaID == id));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<Sistema> GetAll()
        {
            try
            {
                return context.Sistemi.ToList();
            }
            catch { }

            return new List<Sistema>();
        }

        public Sistema? GetByID(int id)
        {
            try
            {
                return context.Sistemi.SingleOrDefault(s => s.SistemaID == id);
            }
            catch { }

            return null;
        }

        public bool Insert(Sistema t)
        {
            try
            {
                context.Sistemi.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Sistema t)
        {
            try
            {
                context.Sistemi.Update(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        public Sistema GetByCodice(string codice)
        {
            try
            {
                return context.Sistemi.Single(s => s.Codice == codice);
            }
            catch { }

            return new Sistema();
        }

        public List<Corpo> GetAllGetBodies()
        {
            try
            {
                return context.Corpi.Include(s => s.ListaSistemi).ToList();
            }
            catch { }

            return new List<Corpo>();
        }

        public bool assignSistema(Sistema sistema, string corpoCodice)
        {
            try
            {
                Corpo corpo = context.Corpi.Single(c => c.Codice == corpoCodice);
                corpo.ListaSistemi.Add(sistema);
                sistema.ListaCorpi.Add(corpo);
                context.SaveChanges();
                return true;
            }
            catch { }
            return false;
        }

        public bool removeCorpoFromSistema(string codiceSistema, string codiceCorpo)
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
