using Progetto_Chat.Models;

namespace Progetto_Chat.Repositories
{
    public class UtenteRepository : IRepository<Utente>
    {
        #region context / database
        readonly ProgettoChatContext context;

        public UtenteRepository (ProgettoChatContext context)
        {
            this.context = context;
        }
        #endregion

        #region Implementazione interfaccia
        public bool DeleteByID(int id)
        {
            try
            {
                context.Utenti.Remove(context.Utenti.Single(u => u.UtenteID == id));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<Utente> GetAll()
        {
            try
            {
                return context.Utenti.ToList();
            }
            catch { }

            return new List<Utente>();
        }

        public Utente GetByID(int id)
        {
            try
            {
                return context.Utenti.Single(u => u.UtenteID == id);
            }
            catch { }

            return new Utente();
        }

        public bool Insert(Utente t)
        {
            try
            {
                context.Utenti.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Utente t)
        {
            try
            {
                context.Utenti.Update(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        #region Metodi personalizzati
        public bool DeleteByEmail(string email)
        {
            try
            {
                context.Utenti.Remove(context.Utenti.Single(u => u.Email == email));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool isPasswordCorrectByEmail(string email, string password)
        {
            try
            {
                if (context.Utenti.Where(u => u.Email == email && u.Pass == password).Count() > 0)
                    return true;

                return false;
            }
            catch { }

            return false;
        }

        public bool isPasswordCorrectByNickname(string nickname, string password)
        {
            try
            {
                if (context.Utenti.Where(u => u.Nickname == nickname && u.Pass == password).Count() > 0)
                    return true;
            }
            catch { }

            return false;
        }

        public string GetNickname(string email)
        {
            try
            {
                return context.Utenti.Single(u => u.Email == email).Nickname;
            }
            catch { }

            return "";
        }

        public bool UserExistsByNickname(string nickname)
        {
            try
            {
                if (context.Utenti.Where(u => u.Nickname == nickname).ToList().Count() > 0)
                    return true;
            }
            catch { }

            return false;
        }

        public int GetIdByNickname(string nickname)
        {
            try
            {
                return context.Utenti.Single(u => u.Nickname == nickname).UtenteID;
            }
            catch { }

            return 0;
        }

        public Utente GetUserByNickname(string nickname)
        {
            try
            {
                return context.Utenti.Single(u => u.Nickname == nickname);
            }
            catch { }

            return new Utente();
        }

        public Utente GetUtenteByEmail(string email)
        {
            try
            {
                return context.Utenti.Single(u => u.Email == email);
            }
            catch { }

            return new Utente();
        }
        #endregion
    }
}
