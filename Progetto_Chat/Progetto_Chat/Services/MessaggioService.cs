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

        #region Metodi privati
        List<MessaggioDTO> ConverListToDTO(List<Messaggio> messaggi)
        {
            return messaggi.Select(m => new MessaggioDTO()
            {
                SendDate = m.DataInvio,
                Text = m.Testo,
                Sender = utenteService.ConvertUserToDTO(m.Mittente),
            }).ToList();
        }
        #endregion

        public bool Send(MessaggioDTO messaggioDTO, StanzaDTO stanzaDTO, UtenteDTO utenteDTO)
        {
            Stanza stanza = stanzaService.GetStanzaFromTitle(stanzaDTO);
            Utente utente = utenteService.GetUserByNickname(utenteDTO);

            Messaggio messaggio = new Messaggio()
            {
                Mittente = utente,
                UtenteRIF = utente.UtenteID,
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

        public List<MessaggioDTO> GetMessagesOfRoom(StanzaDTO stanza)
        {
            Stanza temp = stanzaService.GetStanzaFromTitle(stanza);

            return ConverListToDTO(repository.GetAllOfRoom(temp));
        }
    }
}
