using System.ComponentModel.DataAnnotations;

namespace Progetto_Chat.DTO
{
    public class StanzaDTO
    {
        [Required]
        [StringLength(30)]
        public string Title { get; set; } = null!;

        [StringLength(400)]
        public string? Description { get; set; }

        public UtenteDTO? Admin { get; set; }

        public ICollection<UtenteDTO> Users { get; set; } = new List<UtenteDTO>();

        public ICollection<MessaggioDTO> Messages { get; set; } = new List<MessaggioDTO>();
    }
}
