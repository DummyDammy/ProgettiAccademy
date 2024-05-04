using Progetto_Chat.DTO;
using Progetto_Chat.Models;
using Progetto_Chat.Repositories;

namespace Progetto_Chat.Services
{
    public class StanzaService
    {
        #region repository / utenteService
        readonly StanzaRepository repository;
        readonly UtenteService utenteService;

        public StanzaService (StanzaRepository repository, UtenteService utenteService)
        {
            this.repository = repository;
            this.utenteService = utenteService;
        }
        #endregion

        #region Metodi privati
        List<StanzaDTO> ConvertListToDTO(List<Stanza> stanze)
        {
            return stanze.Select(s => new StanzaDTO()
            {
                Title = s.Titolo,
                Admin = utenteService.ConvertUserToDTO(s.Amministratore),
                Description = s.Descrizione,
                Messages = ConvertMessageListToDTO(s.Messaggi.ToList()),
                Users = s.Utenti.Select(u => new UtenteDTO()
                {
                    Nick = u.Nickname,
                    Password = u.Pass,
                    Post = u.Email
                }).ToList()

            }).ToList();
        }

        StanzaDTO ConvertToDTO(Stanza stanza)
        {
            return new StanzaDTO()
            {
                Title = stanza.Titolo,
                Description = stanza.Descrizione,
                Admin = utenteService.ConvertUserToDTO(stanza.Amministratore),
                Messages = ConvertMessageListToDTO(stanza.Messaggi.ToList()),
                Users = stanza.Utenti.Select(u => utenteService.ConvertUserToDTO(u)).ToList()
            };
        }

        List<MessaggioDTO> ConvertMessageListToDTO(List<Messaggio> messaggi)
        {
            return messaggi.Select(m => new MessaggioDTO()
            {
                SendDate = m.DataInvio,
                Text = m.Testo,
                Sender = utenteService.ConvertUserToDTO(m.Mittente),
            }).ToList();
        }
        #endregion

        public bool Insert(StanzaDTO stanza)
        {
            if (stanza.Admin is not null)
                if (utenteService.UserExists(stanza.Admin))
                {
                    Utente adminRIF = utenteService.GetUserByNickname(stanza.Admin);

                    if (adminRIF != new Utente())
                        return repository.Insert(new Stanza()
                        {
                            Titolo = stanza.Title,
                            Descrizione = stanza.Description,
                            AmministratoreRIF = adminRIF.UtenteID,
                            Amministratore = adminRIF,
                            Utenti = new List<Utente>()
                            {
                                adminRIF
                            }
                        });
                }

            return false;
        }

        public bool Delete(StanzaDTO stanza)
        {
            return repository.DeleteByTitle(stanza.Title);
        }

        public bool AddMemberToRoom(StanzaDTO stanza, UtenteDTO utente)
        {
            return repository.AddMember(new Stanza() { Titolo = stanza.Title }, utenteService.GetUserByNickname(utente));
        }

        public bool RemoveMemberFromRoom(StanzaDTO stanza, UtenteDTO utente)
        {
            return repository.RemoveMember(new Stanza() { Titolo = stanza.Title }, utenteService.GetUserByNickname(utente));
        }

        public Stanza GetStanzaFromTitle(StanzaDTO stanza)
        {
            return repository.GetStanzaFromTitle(stanza.Title);
        }

        public bool AddMessageToRoom(Stanza stanza, Messaggio messaggio)
        {
            return repository.AddMessageToRoom(stanza, messaggio);
        }

        public List<StanzaDTO> GetAllOfUser(UtenteDTO utente)
        {
            return ConvertListToDTO(repository.GetAllOfUser(utenteService.GetUserByNickname(utente)));
        }

        public List<StanzaDTO> GetRoomsWhereAdmin(UtenteDTO utente)
        {
            if(utente.Nick is not null)
                return ConvertListToDTO(repository.GetRoomsWhereAdmin(utente.Nick));

            return new List<StanzaDTO>();
        }

        public List<StanzaDTO> GetRoomsWhereNotAdmin(UtenteDTO utente)
        {
            if (utente.Nick is not null)
                return ConvertListToDTO(repository.GetRoomsWhereNotAdmin(utente.Nick));

            return new List<StanzaDTO>();
        }

        public StanzaDTO GetByTitle(StanzaDTO stanza)
        {
            return ConvertToDTO(repository.GetByTitle(stanza.Title));
        }
    }
}
