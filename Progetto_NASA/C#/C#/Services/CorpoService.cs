using C_.DTO;
using C_.Models;
using C_.Repositories;

namespace C_.Services
{
    public class CorpoService
    {
        #region repository
        readonly CorpoRepository repository;

        public CorpoService(CorpoRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Metodi privati
        Corpo GetCorpoByCodice(CorpoDTO corpo)
        {
            if (corpo.Code is not null)
            {
                return repository.GetByCodice(corpo.Code);
            }

            return new Corpo();
        }

        List<CorpoDTO> ConvertToDTO(List<Corpo> corpi)
        {
            List<CorpoDTO> corpiDTO = new List<CorpoDTO>();

            foreach (Corpo corpo in corpi)
            {
                List<SistemaDTO> sistemi = new List<SistemaDTO>();

                foreach (Sistema sistema in corpo.ListaSistemi)
                {
                    sistemi.Add(new SistemaDTO()
                    {
                        Code = sistema.Codice,
                        Name = sistema.Nome,
                        Type = sistema.Tipo
                    });
                }

                corpiDTO.Add(new CorpoDTO()
                {
                    Code = corpo.Codice,
                    Name = corpo.Nome,
                    Type = corpo.Tipo,
                    DiscoveryDate = corpo.DataScoperta,
                    Discoverer = corpo.Scopritore,
                    Distance = corpo.Distanza,
                    AngularCoordinate = corpo.CoordinataAngolare,
                    RadialCoordinate = corpo.CoordinataRadiale,
                    SystemList = sistemi
                });
            }

            return corpiDTO;
        }
        #endregion

        public List<CorpoDTO> GetAll()
        {
            return repository.GetAll().Select(c => new CorpoDTO()
            {
                Code = c.Codice,
                Name = c.Nome,
                Type = c.Tipo,
                DiscoveryDate = c.DataScoperta,
                Discoverer = c.Scopritore,
                Distance = c.Distanza,
                AngularCoordinate = c.CoordinataAngolare,
                RadialCoordinate = c.CoordinataRadiale
            }).ToList();
        }

        public CorpoDTO GetByCodice(CorpoDTO corpoDTO)
        {
            if (corpoDTO.Code is not null)
            {
                Corpo corpo = GetCorpoByCodice(corpoDTO);
                return new CorpoDTO()
                {
                    Code = corpo.Codice,
                    Name = corpo.Nome,
                    Type = corpo.Tipo,
                    DiscoveryDate = corpo.DataScoperta,
                    Discoverer = corpo.Scopritore,
                    Distance = corpo.Distanza,
                    AngularCoordinate = corpo.CoordinataAngolare,
                    RadialCoordinate = corpo.CoordinataRadiale
                };
            }

            return new CorpoDTO();
        }

        public bool DeleteByCodice(CorpoDTO corpo)
        {
            if (corpo.Code is not null)
            {
                return repository.DeleteByID(GetCorpoByCodice(corpo).CorpoID);
            }

            return false;
        }

        public bool Insert(CorpoDTO corpo)
        {
            return repository.Insert(new Corpo() 
            { 
                Codice = corpo.Code, 
                Nome = corpo.Name, 
                Tipo = corpo.Type , 
                DataScoperta = corpo.DiscoveryDate , 
                Distanza = corpo.Distance , 
                Scopritore = corpo.Discoverer , 
                CoordinataAngolare = corpo.AngularCoordinate , 
                CoordinataRadiale = corpo.RadialCoordinate});
        }

        public List<CorpoDTO> GetAllGetSystems()
        {
            return ConvertToDTO(repository.GetAllGetSystems());
        }

        public bool assign(SistemaDTO sistema, CorpoDTO corpo)
        {
            if (sistema.Code is not null)
                return repository.assignCorpo(GetCorpoByCodice(corpo), sistema.Code);

            return false;
        }

        public bool Update(CorpoDTO corpoDTO)
        {
            Corpo corpo = GetCorpoByCodice(corpoDTO);

            corpo.Nome = corpoDTO.Name;
            corpo.DataScoperta = corpoDTO.DiscoveryDate;
            corpo.Tipo = corpoDTO.Type;
            corpo.Distanza = corpoDTO.Distance;
            corpo.Scopritore = corpoDTO.Discoverer;
            corpo.CoordinataAngolare = corpoDTO.AngularCoordinate;
            corpo.CoordinataRadiale = corpoDTO.RadialCoordinate;

            return repository.Update(corpo);
        }

        public bool RemoveCorpoFromSistema(CorpoDTO corpoDTO, SistemaDTO sistemaDTO)
        {
            if (corpoDTO.Code is not null && sistemaDTO.Code is not null)
                return repository.removeSistemaFromCorpo(corpoDTO.Code, sistemaDTO.Code);

            return false;
        }
    }
}
