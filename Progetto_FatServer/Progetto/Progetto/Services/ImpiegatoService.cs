using Progetto.Models;
using Progetto.Repositories;

namespace Progetto.Services
{
    public class ImpiegatoService
    {
        #region repository
        readonly ImpiegatoRepository repository;

        public ImpiegatoService(ImpiegatoRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        public List<Impiegato> GetAll()
        {
            return repository.GetAll();
        }

        public bool Insert(Impiegato impiegato)
        {
            int cittaRIF = repository.GetCittaRIF(impiegato.CittaRifNavigation.Citta);

            impiegato.CittaRif = cittaRIF;

            return repository.Insert(impiegato);
        }
    }
}
