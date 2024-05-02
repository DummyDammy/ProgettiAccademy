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
                Admin = 

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
                            Amministratore = adminRIF
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
            return repository.GetAllOfUser(utenteService.GetUserByNickname(utente));
        }
    }
}
