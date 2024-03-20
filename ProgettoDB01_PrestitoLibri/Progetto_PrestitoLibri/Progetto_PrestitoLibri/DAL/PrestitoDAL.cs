using Progetto_PrestitoLibri.Models;
using Progetto_PrestitoLibri.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_PrestitoLibri.DAL
{
    internal class PrestitoDAL : IDal<Prestito>
    {
        static PrestitoDAL? instance;

        public static PrestitoDAL getInstance()
        {
            if (instance == null)
                instance = new PrestitoDAL();
            return instance;
        }

        PrestitoDAL() { }

        public bool deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Prestito> findAll()
        {
            throw new NotImplementedException();
        }

        public Prestito findById(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Prestito t)
        {
            bool controllo = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Libro (dataInizio, dataRitorno, utenteRIF, libroRIF) VALUES (@dataInizio,@dataRitorno,@utenteRIF, @libroRIF)";
                cmd.Parameters.AddWithValue("@dataInizio", t.DataPrestito);
                cmd.Parameters.AddWithValue("@dataRitorno", t.DataRitorno);
                cmd.Parameters.AddWithValue("@utenteRIF", t.UtenteRIF);
                cmd.Parameters.AddWithValue("@libroRIF", t.LibroRIF);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        controllo = true;

                    con.Close();
                }
                catch (Exception) { Console.WriteLine("Utente non isnerito"); }
                finally { con.Close(); }

            }

            return controllo;
        }

        public bool update(Prestito t)
        {
            throw new NotImplementedException();
        }
    }
}
