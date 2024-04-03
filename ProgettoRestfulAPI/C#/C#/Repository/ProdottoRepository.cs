using C_.Models;

namespace C_.Repository
{
    public class ProdottoRepository
    {
        #region Singleton
        static ProdottoRepository? instance;

        public static ProdottoRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ProdottoRepository();
            }
            return instance;
        }

        ProdottoRepository() { }
        #endregion

        public bool DeleteByCodice(string codice)
        {
            bool controllo = false;
            try
            {
                using (ProgettoApiContext context = new ProgettoApiContext())
                {
                    context.Prodottos.Remove(context.Prodottos.Single(p => p.Codice == codice));
                    context.SaveChanges();
                    controllo = true;
                }
            }
            catch { }

            return controllo;
        }

        public List<Prodotto> GetAll()
        {
            try
            {
                using (ProgettoApiContext context = new ProgettoApiContext())
                {
                    return context.Prodottos.ToList();
                }
            }
            catch { }

            return new List<Prodotto>();
        }

        public bool Insert(Prodotto prodotto)
        {
            bool controllo = false;
            try
            {
                using (ProgettoApiContext context = new ProgettoApiContext())
                {
                    context.Prodottos.Add(prodotto);
                    context.SaveChanges();
                    controllo = true;
                }
            }
            catch { }
            return controllo;
        }

        public bool Update(Prodotto prodotto)
        {
            bool controllo = false;

            try
            {
                using (ProgettoApiContext context = new ProgettoApiContext())
                {
                    Prodotto prodottoVecchio = context.Prodottos.Single(p => p.Codice == prodotto.Codice);

                    prodotto.ProdottoId = prodottoVecchio.ProdottoId;
                    prodotto.Codice = prodottoVecchio.Codice;
                    prodotto.Nome = prodotto.Nome is null ? prodottoVecchio.Nome : prodotto.Nome;
                    prodotto.Descrizione = prodotto.Descrizione is null ? prodottoVecchio.Descrizione : prodotto.Descrizione;
                    prodotto.Prezzo = prodotto.Prezzo < 0 ? prodottoVecchio.Prezzo : prodotto.Prezzo;
                    prodotto.Quantita = prodotto.Quantita < 0 ? prodottoVecchio.Quantita : prodotto.Quantita;
                    prodotto.Categoria = prodotto.Categoria is null ? prodottoVecchio.Categoria : prodotto.Categoria;

                    context.Entry(prodottoVecchio).CurrentValues.SetValues(prodotto);
                    context.SaveChanges();
                    controllo = true;
                }
            }
            catch { }

            return controllo;
        }

        public Prodotto? GetByCodice(string codice)
        {
            try
            {
                using (ProgettoApiContext context = new ProgettoApiContext())
                {
                    return context.Prodottos.SingleOrDefault(p => p.Codice == codice);
                }
            }
            catch { }

            return null;
        }
    }
}
