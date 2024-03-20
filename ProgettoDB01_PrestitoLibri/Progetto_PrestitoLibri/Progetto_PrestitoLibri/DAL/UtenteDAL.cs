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
    internal class UtenteDAL : IDal<Utente>
    {
        static UtenteDAL? instance;

        static List<Utente>? utenti;

        public static UtenteDAL getInstance()
        {
            if (instance == null)
                instance = new UtenteDAL();
            return instance;
        }

        UtenteDAL() { }

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Utente WHERE utenteID = @utenteID";
                cmd.Parameters.AddWithValue("@utenteID", id);

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

        public List<Utente>? findAll()
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT utenteID, nome, cognome, email FROM Utente";

                try
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (utenti is null)
                            utenti = new List<Utente>();

                        utenti.Add(new Utente()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Nome = reader[1].ToString(),
                            Cognome = reader[2].ToString(),
                            Email = reader[3].ToString()
                        });
                    }

                    con.Close();
                }
                catch (Exception) { Console.WriteLine("Utente non isnerito"); }
                finally { con.Close(); }
            }

            return utenti;
        }

        public Utente? findById(int id)
        {
            Utente utente = new Utente();
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT utenteID, nome, cognome, email FROM Utente WHERE utenteID = @utenteID";
                cmd.Parameters.AddWithValue("@utenteID", id);

                try
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        utente.Id = Convert.ToInt32(reader[0]);
                        utente.Nome = reader[1].ToString();
                        utente.Cognome = reader[2].ToString();
                        utente.Email = reader[3].ToString();
                    }

                    con.Close();
                }
                catch (Exception) { Console.WriteLine("Utente non isnerito"); }
                finally { con.Close(); }
            }

            return utente;
        }

        public bool insert(Utente t)
        {
            bool controllo = false;

            using(SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Utente (nome, cognome, email) VALUES (@nome,@cognome,@email)";
                cmd.Parameters.AddWithValue("@nome", t.Nome);
                cmd.Parameters.AddWithValue("@cognome", t.Cognome);
                cmd.Parameters.AddWithValue("@email", t.Email);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        controllo = true;

                    con.Close();
                }
                catch(Exception ex) { Console.WriteLine($"Utente non inserito {ex}"); }
                finally { con.Close(); }

            }

            return controllo;
        }

        public bool update(Utente t)
        {
            bool controllo = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Utente SET nome = @nome, cognome = @cognome, email = @email WHERE utenteID = @utenteID";
                cmd.Parameters.AddWithValue("@utenteID", t.Id);
                cmd.Parameters.AddWithValue("@nome", t.Nome);
                cmd.Parameters.AddWithValue("@cognome", t.Cognome);
                cmd.Parameters.AddWithValue("@email", t.Email);

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

        public string stampaLista()
        {
            string stringa = "";

            if (utenti is null)
                utenti = new List<Utente>();

            foreach (Utente utente in utenti)
            {
                stringa += utente.ToString() + "\n";
            }

            return stringa;
        }
    }
}
