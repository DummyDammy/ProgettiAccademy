namespace C_.DTO
{
    public class PersonaggioDTO
    {
        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Veichle { get; set; } = null!;

        public int Cost { get; set; }

        public GiocatoreDTO? Player { get; set; }
    }
}
