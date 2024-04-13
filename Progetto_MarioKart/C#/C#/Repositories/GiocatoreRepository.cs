using C_.Models;
using Microsoft.EntityFrameworkCore;

namespace C_.Repositories
{
    public class GiocatoreRepository : IRepository<Giocatore>
    {
        #region context
        readonly MarioKartContext context;

        public GiocatoreRepository(MarioKartContext context)
        {
            this.context = context;
        }
        #endregion

        #region Implementazione interfaccia
        public bool DeleteByID(int id)
        {
            try
            {
                context.Remove(context.Giocatori.Single(s => s.GiocatoreID == id));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<Giocatore> GetAll()
        {
            try
            {
                return context.Giocatori.ToList();
            }
            catch { }

            return new List<Giocatore>();
        }

        public Giocatore? GetByID(int id)
        {
            try
            {
                return context.Giocatori.SingleOrDefault(s => s.GiocatoreID == id);
            }
            catch { }

            return null;
        }

        public bool Insert(Giocatore t)
        {
            try
            {
                context.Giocatori.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Giocatore t)
        {
            try
            {
                context.Giocatori.Update(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        public bool DeleteByColor(string colore)
        {
            try
            {
                context.Remove(context.Giocatori.Single(s => s.Colore == colore));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public Giocatore GetByColor(string colore)
        {
            try
            {
                return context.Giocatori.Include(s => s.Personaggi).Single(s => s.Colore == colore);
            }
            catch { }

            return new Giocatore();
        }

        public bool assignPersonaggio(Giocatore giocatore, Personaggio personaggio)
        {
            try
            {
                personaggio.Giocatore = giocatore;
                personaggio.GiocatoreRIF = giocatore.GiocatoreID;
                giocatore.Personaggi.Add(personaggio);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<Giocatore> GetAllGetPersonaggi()
        {
            try
            {
                return context.Giocatori.Include(p => p.Personaggi).ToList();
            }
            catch { }

            return new List<Giocatore>();
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

        public Giocatore GetByColorGetPersonaggi(string colore)
        {
            try
            {
                return context.Giocatori.Include(s => s.Personaggi).Single(s => s.Colore == colore);
            }
            catch { }

            return new Giocatore();
        }

        public bool DeleteCharacterFromTeam(Giocatore giocatore, Personaggio personaggio)
        {
            try
            {
                giocatore.Personaggi.Remove(personaggio);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
    }
}
