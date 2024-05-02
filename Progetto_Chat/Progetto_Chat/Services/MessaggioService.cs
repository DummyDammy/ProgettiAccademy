using Progetto_Chat.DTO;
using Progetto_Chat.Models;
using Progetto_Chat.Repositories;

namespace Progetto_Chat.Services
{
    public class MessaggioService
    {
        #region repository / stanzaService / utenteService
        readonly MessaggioRepository repository;
        readonly StanzaService stanzaService;
        readonly UtenteService utenteService;

        public MessaggioService (MessaggioRepository repository, StanzaService stanzaService, UtenteService utenteService)
        {
            this.repository = repository;
            this.stanzaService = stanzaService;
            this.utenteService = utenteService;
        }
        #endregion

        public bool Send(MessaggioDTO messaggioDTO, StanzaDTO stanzaDTO, UtenteDTO utente)
        {
            Stanza stanza = stanzaService.GetStanzaFromTitle(stanzaDTO);

            Messaggio messaggio = new Messaggio()
            {
                Mittente = utenteService.GetUserByNickname(utente),
                UtenteRIF = utenteService.GetUserByNickname(utente).UtenteID,
                StanzaRIFNavigation = stanza,
                StanzaRIF = stanza.StanzaID,
                Testo = messaggioDTO.Text
            };

            if (repository.Insert(messaggio))
            {
                if(stanzaService.AddMessageToRoom(stanza, messaggio))
                {
                    return true;
                }
            }

            return false;

        }
    }
}
