using C_.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace C_.Repositories
{
    public class PersonaggioRepository : IRepository<Personaggio>
    {
        #region context
        readonly MarioKartContext context;

        public PersonaggioRepository(MarioKartContext context)
        {
            this.context = context;
        }
        #endregion

        #region Implementazione interfaccia
        public bool DeleteByID(int id)
        {
            try
            {
                context.Remove(context.Personaggi.Single(s => s.PersonaggioID == id));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<Personaggio> GetAll()
        {
            try
            {
                return context.Personaggi.ToList();
            }
            catch { }

            return new List<Personaggio>();
        }

        public Personaggio? GetByID(int id)
        {
            try
            {
                return context.Personaggi.SingleOrDefault(s => s.PersonaggioID == id);
            }
            catch { }

            return null;
        }

        public bool Insert(Personaggio t)
        {
            try
            {
                context.Personaggi.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Personaggio t)
        {
            try
            {
                context.Personaggi.Update(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        public bool DeleteByNome(string nome) 
        {
            try
            {
                context.Remove(context.Personaggi.Single(s => s.Nome == nome));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public Personaggio GetByNome(string nome)
        {
            try
            {
                return context.Personaggi.Single(s => s.Nome == nome);
            }
            catch { }

            return new Personaggio();
        }

        public List<Personaggio> GetAllGetGiocatori()
        {
            try
            {
                return context.Personaggi.Include(p => p.Giocatore).ToList();
            }
            catch { }

            return new List<Personaggio>();
        }
    }
}
