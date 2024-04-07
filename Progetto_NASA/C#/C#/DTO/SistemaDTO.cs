using C_.Models;

namespace C_.DTO
{
    public class SistemaDTO
    {

        public string? Code { get; set; } = null!;

        public string? Name { get; set; } = null!;

        public string? Type { get; set; } = null!;

        public virtual List<Corpo>? BodyList { get; set; } = new List<Corpo>();
    }
}
