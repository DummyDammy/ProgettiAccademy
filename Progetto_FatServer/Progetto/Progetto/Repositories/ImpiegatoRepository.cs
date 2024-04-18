using Microsoft.EntityFrameworkCore;
using Progetto.Models;

namespace Progetto.Repositories
{
    public class ImpiegatoRepository : IRepository<Impiegato>
    {
        #region context
        readonly ProgettoFatServerContext context;

        public ImpiegatoRepository(ProgettoFatServerContext context)
        {
            this.context = context;
        }
        #endregion

        #region Implementazione interfaccia
        public bool Delete(Impiegato t)
        {
            try
            {
                context.Impiegatos.Remove(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public Impiegato Get(int id)
        {
            try
            {
                return context.Impiegatos.Single(i => i.ImpiegatoId == id);
            }
            catch { }

            return new Impiegato();
        }

        public List<Impiegato> GetAll()
        {
            try
            {
                return context.Impiegatos.Include(i => i.RepartoRifNavigation).Include(i => i.CittaRifNavigation).ToList();
            }
            catch { }

            return new List<Impiegato>();
        }

        public bool Insert(Impiegato t)
        {
            try
            {
                context.Impiegatos.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Impiegato t)
        {
            try
            {
                context.Impiegatos.Update(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        public int GetCittaRIF(string citta)
        {
            try
            {
                return context.Citta.Single(c => c.Citta == citta).CittaId;
            }
            catch { }

            return 0;
        }
    }
}
