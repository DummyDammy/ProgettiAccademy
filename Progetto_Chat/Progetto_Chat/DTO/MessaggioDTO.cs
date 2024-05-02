using System.ComponentModel.DataAnnotations;

namespace Progetto_Chat.DTO
{
    public class MessaggioDTO
    {
        public DateTime? SendDate { get; set; } = DateTime.Now;

        public UtenteDTO? Sender { get; set; } = null!;

        public StanzaDTO? Room { get; set; } = null!;

        [Required]
        public string Text { get; set; } = null!;
    }
}
