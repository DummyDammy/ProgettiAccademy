using C_.DTO;
using C_.Models;
using C_.Repositories;

namespace C_.Services
{
    public class GiocatoreService
    {
        #region repository
        readonly GiocatoreRepository repository;

        public GiocatoreService(GiocatoreRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Metodi privati
        List<GiocatoreDTO> ConvertToGiocatoriDTO(List<Giocatore> giocatori)
        {
            return giocatori.Select(g => new GiocatoreDTO()
            {
                Name = g.Nome,
                Color = g.Colore,
                Credits = g.Crediti,
                Characters = ConvertToPersonaggiDTO(g.Personaggi.ToList())
            }).ToList();
        }

        GiocatoreDTO ConvertToGiocatoreDTO(Giocatore giocatore)
        {
            return new GiocatoreDTO()
            {
                Name = giocatore.Nome,
                Color = giocatore.Colore,
                Credits = giocatore.Crediti,
                Characters = ConvertToPersonaggiDTO(giocatore.Personaggi.ToList())
            };
        }

        List<PersonaggioDTO> ConvertToPersonaggiDTO(List<Personaggio> personaggi)
        {
            return personaggi.Select(p => new PersonaggioDTO()
            {
                Name = p.Nome,
                Category = p.Categoria,
                Cost = p.Costo,
                Veichle = p.Mezzo
            }).ToList();
        }
        #endregion

        public List<GiocatoreDTO> GetAll()
        {
            return ConvertToGiocatoriDTO(repository.GetAll());
        }

        public bool Insert(GiocatoreDTO giocatore)
        {
            if (repository.GetAll().Count >= 3)
                return false;

            if (repository.GetAll().SingleOrDefault(g => g.Colore.ToLower() == giocatore.Color.ToLower()) is not null)
                return false;

            return repository.Insert(new Giocatore()
            {
                Nome = giocatore.Name,
                Colore = giocatore.Color
            });
        }

        public bool Delete(GiocatoreDTO giocatore)
        {
            return repository.DeleteByColor(giocatore.Color);
        }

        public bool Update(GiocatoreDTO giocatoreDTO)
        {
            Giocatore giocatore = repository.GetByColor(giocatoreDTO.Color);

            giocatore.Nome = giocatoreDTO.Name;
            giocatore.Crediti = giocatoreDTO.Credits;

            return repository.Update(giocatore);
        }

        public GiocatoreDTO GetByColor(GiocatoreDTO giocatore)
        {
            return ConvertToGiocatoreDTO(repository.GetByColor(giocatore.Color));
        }

        public bool assignPersonaggio(GiocatoreDTO giocatoreDTO, PersonaggioDTO personaggioDTO)
        {
            Personaggio personaggio = repository.GetByNome(personaggioDTO.Name);

            if (personaggio.GiocatoreRIF is not null)
                return false;

            Giocatore giocatore = repository.GetByColorGetPersonaggi(giocatoreDTO.Color);

            if (giocatore.Personaggi.SingleOrDefault(p => p.Categoria.ToLower() == personaggio.Categoria.ToLower()) is not null)
                return false;

            if (giocatore.Crediti < personaggio.Costo)
                return false;

            giocatore.Crediti -= personaggio.Costo;

            return repository.assignPersonaggio(giocatore, personaggio);
        }

        public List<GiocatoreDTO> GetAllGetPersonaggi()
        {
            return ConvertToGiocatoriDTO(repository.GetAllGetPersonaggi());
        }

        public bool DeleteCharacterFromTeam(GiocatoreDTO giocatoreDTO, PersonaggioDTO personaggioDTO)
        {
            Personaggio personaggio = repository.GetByNome(personaggioDTO.Name);

            Giocatore giocatore = repository.GetByColorGetPersonaggi(giocatoreDTO.Color);

            if (!giocatore.Personaggi.Contains(personaggio))
                return false;

            if (repository.GetAll().SingleOrDefault(g => g.Colore.ToLower() == giocatoreDTO.Color.ToLower()) is null)
                return false;

            giocatore.Crediti += personaggio.Costo;

            return repository.DeleteCharacterFromTeam(giocatore, personaggio);
        }
    }
}
