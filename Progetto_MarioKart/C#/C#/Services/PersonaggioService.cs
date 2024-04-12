using C_.DTO;
using C_.Models;
using C_.Repositories;

namespace C_.Services
{
    public class PersonaggioService
    {
        #region repository
        readonly PersonaggioRepository repository;

        public PersonaggioService(PersonaggioRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Metodi privati
        List<PersonaggioDTO> ConvertToPersonaggiDTO(List<Personaggio> personaggi)
        {
            return personaggi.Select(p => new PersonaggioDTO()
            {
                Name = p.Nome,
                Category = p.Categoria,
                Cost = p.Costo,
                Veichle = p.Mezzo,
                Player = ConvertToGiocatoreDTO(p.Giocatore)
            }).ToList();
        }

        PersonaggioDTO ConvertToPersonaggioDTO(Personaggio personaggio)
        {
            return new PersonaggioDTO()
            {
                Name = personaggio.Nome,
                Category = personaggio.Categoria,
                Cost = personaggio.Costo,
                Veichle = personaggio.Mezzo,
                Player = ConvertToGiocatoreDTO(personaggio.Giocatore)
            };
        }

        GiocatoreDTO? ConvertToGiocatoreDTO(Giocatore? giocatore)
        {
            if (giocatore is not null)
                return new GiocatoreDTO()
                {
                    Name = giocatore.Nome,
                    Color = giocatore.Colore,
                    Credits = giocatore.Crediti
                };

            return null;
        }
        #endregion

        public List<PersonaggioDTO> GetAll()
        {
            return ConvertToPersonaggiDTO(repository.GetAll());
        }

        public bool Insert(PersonaggioDTO personaggio)
        {
            if (repository.GetAll().SingleOrDefault(p => p.Nome.ToLower() == personaggio.Name.ToLower()) is not null)
                return false;

            return repository.Insert(new Personaggio()
            {
                Nome = personaggio.Name,
                Categoria = personaggio.Category,
                Costo = personaggio.Cost,
                Mezzo = personaggio.Veichle
            });
        }

        public bool Delete(PersonaggioDTO personaggio)
        {
            return repository.DeleteByNome(personaggio.Name);
        }

        public bool Update(PersonaggioDTO personaggioDTO)
        {
            Personaggio personaggio = repository.GetByNome(personaggioDTO.Name);

            personaggio.Costo = personaggioDTO.Cost;
            personaggio.Categoria = personaggioDTO.Category;
            personaggio.Mezzo = personaggioDTO.Veichle;

            return repository.Update(personaggio);
        }

        public PersonaggioDTO GetByNome(PersonaggioDTO personaggio)
        {
            return ConvertToPersonaggioDTO(repository.GetByNome(personaggio.Name));
        }

        public List<PersonaggioDTO> GetAllGetGiocatori()
        {
            return ConvertToPersonaggiDTO(repository.GetAllGetGiocatori());
        }
    }
}
