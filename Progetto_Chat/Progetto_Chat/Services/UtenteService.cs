using Progetto_Chat.DTO;
using Progetto_Chat.Models;
using Progetto_Chat.Repositories;

namespace Progetto_Chat.Services
{
    public class UtenteService
    {
        #region repository / stanzaService
        readonly UtenteRepository repository;

        public UtenteService (UtenteRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Metodi privati
        string CreateMD5(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] passwordBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(passwordBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

        bool isPasswordCorrectByEmail(string email, string password)
        {
            return repository.isPasswordCorrectByEmail(email, CreateMD5(password));
        }

        UtenteDTO ConvertToDTO(Utente utente)
        {
            return new UtenteDTO()
            {
                Nick = utente.Nickname,
                Password = utente.Pass,
                Post = utente.Email
            };
        }
        #endregion

        public bool Register(UtenteDTO utente)
        {
            if (utente.Post is not null && utente.Password is not null && utente.Nick is not null)
                return repository.Insert(new Utente()
                {
                    Nickname = utente.Nick,
                    Pass = CreateMD5(utente.Password),
                    Email = utente.Post
                });

            return false;
        }

        public bool Delete(UtenteDTO utente)
        {
            if (utente.Post is not null && utente.Password is not null)
                if (isPasswordCorrectByEmail(utente.Post, utente.Password))
                    return repository.DeleteByEmail(utente.Post);

            return false;
        }

        public string Login(UtenteDTO utente)
        {
            if (utente.Post is not null && utente.Password is not null)
                if (isPasswordCorrectByEmail(utente.Post, utente.Password))
                    return repository.GetNickname(utente.Post);

            return "";
        }

        public bool UserExists(UtenteDTO utente)
        {
            if (utente.Nick is not null)
                return repository.UserExistsByNickname(utente.Nick);

            return false;
        }

        public Utente GetUserByNickname(UtenteDTO utente)
        {
            if (utente.Nick is not null)
                return repository.GetUserByNickname(utente.Nick);

            return new Utente();
        }

        public bool Update(UtenteDTO utente)
        {
            if (utente.Post is null)
                return false;

            Utente temp = repository.GetUtenteByEmail(utente.Post);

            if (utente.Nick is not null && !utente.Nick.Trim().Equals(""))
                temp.Nickname = utente.Nick;

            if (utente.Password is not null && !utente.Password.Equals(""))
                temp.Pass = CreateMD5(utente.Password);

            return repository.Update(temp);
        }

        public UtenteDTO ConvertUserToDTO(Utente utente)
        {
            return ConvertToDTO(utente);
        }

        public UtenteDTO GetUserByEmail(UtenteDTO utente)
        {
            if (utente.Post is not null)
                return ConvertToDTO(repository.GetUtenteByEmail(utente.Post));

            return new UtenteDTO();
        }
    }
}
