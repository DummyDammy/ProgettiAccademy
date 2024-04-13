namespace C_.DTO
{
    public class GiocatoreDTO
    {

        public string Name { get; set; } = null!;

        public int Credits { get; set; }

        public string Color { get; set; } = null!;

        public ICollection<PersonaggioDTO> Characters { get; set; } = new List<PersonaggioDTO>();
    }
}
