using C_.Models;

namespace C_.DTO
{
    public class CorpoDTO
    {

        public string? Code { get; set; } = null!;

        public string? Name { get; set; }

        public DateOnly? DiscoveryDate { get; set; }

        public string? Type { get; set; } = null!;

        public decimal? Distance { get; set; }

        public string? Discoverer {  get; set; }

        public decimal? AngularCoordinate { get; set; }

        public decimal? RadialCoordinate { get; set; }

        public virtual List<SistemaDTO>? SystemList { get; set; } = new List<SistemaDTO>();

    }
}
