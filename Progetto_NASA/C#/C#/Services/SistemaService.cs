using C_.DTO;
using C_.Models;
using C_.Repositories;

namespace C_.Services
{
    public class SistemaService
    {
        #region repository
        readonly SistemaRepository repository;

        public SistemaService(SistemaRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Metodi privati
        Sistema GetSistemaByCodice(SistemaDTO sistema)
        {
            if (sistema.Code is not null)
            {
                return repository.GetByCodice(sistema.Code);
            }

            return new Sistema();
        }
        #endregion

        public List<SistemaDTO> GetAll() 
        {
            return repository.GetAll().Select(s => new SistemaDTO()
            {
                Code = s.Codice,
                Name = s.Nome,
                Type = s.Tipo
            }).ToList();
        }

        public SistemaDTO GetByCodice(SistemaDTO sistema)
        {
            if (sistema.Code is not null) {
                Sistema temp = GetSistemaByCodice(sistema);
                return new SistemaDTO()
                {
                    Code = temp.Codice,
                    Name = temp.Nome,
                    Type = temp.Tipo
                };
            }

            return new SistemaDTO();
        }

        public bool DeleteByCodice(SistemaDTO sistema)
        {
            if (sistema.Code is not null)
            {
                return repository.DeleteByID(GetSistemaByCodice(sistema).SistemaID);
            }

            return false;
        }

        public bool Insert(SistemaDTO sistema)
        {
            return repository.Insert(new Sistema() { Codice = sistema.Code , Nome = sistema.Name , Tipo = sistema.Type });
        }

        public List<Corpo> GetAllGetBodies()
        {
            return repository.GetAllGetBodies();
        }

        public bool assign(CorpoDTO corpo, SistemaDTO sistema)
        {
            if (corpo.Code is not null)
                return repository.assignSistema(GetSistemaByCodice(sistema), corpo.Code);

            return false;
        }

        public bool Update(SistemaDTO sistemaDTO)
        {
            Sistema sistema = GetSistemaByCodice(sistemaDTO);

            sistema.Nome = sistemaDTO.Name;
            sistema.Tipo = sistemaDTO.Type;

            return repository.Update(sistema);
        }

        public bool RemoveSistemaFromCorpo(SistemaDTO sistemaDTO, CorpoDTO corpoDTO)
        {
            if (sistemaDTO.Code is not null && corpoDTO.Code is not null)
                return repository.removeCorpoFromSistema(sistemaDTO.Code, corpoDTO.Code);

            return false;
        }
    }
}
