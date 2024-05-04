using System.ComponentModel.DataAnnotations;

namespace Progetto_Chat.DTO
{
    public class UtenteDTO
    {
        [StringLength(30)]
        public string? Nick { get; set; }

        [StringLength(30)]
        public string? Password { get; set; }

        [StringLength(30)]
        public string? Post { get; set; }

        public ICollection<MessaggioDTO> Messagges { get; set; } = new List<MessaggioDTO>();

        public ICollection<StanzaDTO> Rooms { get; set; } = new List<StanzaDTO>();
    }
}
