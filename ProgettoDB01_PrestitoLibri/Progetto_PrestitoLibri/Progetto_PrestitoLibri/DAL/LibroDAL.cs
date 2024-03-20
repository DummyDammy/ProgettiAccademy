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
    internal class LibroDAL : IDal<Libro>
    {
        static List<Libro>? libri;

        static LibroDAL? instance;

        public static LibroDAL getInstance()
        {
            if (instance == null)
                instance = new LibroDAL();
            return instance;
        }

        LibroDAL() { }
        public bool deleteById(int id)
        {
            bool controllo = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Libro WHERE libroID = @libroID";
                cmd.Parameters.AddWithValue("@utenteID", id);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        controllo = true;

                    con.Close();
                }
                catch (Exception) { Console.WriteLine("Errore"); }
                finally { con.Close(); }

            }

            return controllo;
        }

        public List<Libro>? findAll()
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroID, titolo, annoPubblicazione, isDisponibile FROM Libro";

                try
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (libri is null)
                            libri = new List<Libro>();

                        libri.Add(new Libro()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Titolo = reader[1].ToString(),
                            DataPubblicazione = Convert.ToDateTime(reader[2]),
                            isDisponibile = Convert.ToBoolean(reader[3])
                        }) ;
                    }

                    con.Close();
                }
                catch (Exception) { Console.WriteLine("Errore"); }
                finally { con.Close(); }
            }

            return libri;
        }

        public Libro findById(int id)
        {
            Libro libro = new Libro();
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroID, titolo, annoPubblicazione, isDisponibile FROM Libro WHERE libroID = @libroID";
                cmd.Parameters.AddWithValue("@libroID", id);

                try
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        libro.Id = Convert.ToInt32(reader[0]);
                        libro.Titolo = reader[1].ToString();
                        libro.DataPubblicazione = Convert.ToDateTime(reader[2]);
                        libro.isDisponibile = Convert.ToBoolean(reader[3]);
                    }

                    con.Close();
                }
                catch (Exception) { Console.WriteLine("Libro non trovato"); }
                finally { con.Close(); }
            }

            return libro;
        }

        public bool insert(Libro t)
        {
            bool controllo = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Libro (titolo, annoPubblicazione, isDisponibile) VALUES (@titolo,@annoPubblicazione,@isDisponibile)";
                cmd.Parameters.AddWithValue("@titolo", t.Titolo);
                cmd.Parameters.AddWithValue("@annoPubblicazione", t.DataPubblicazione);
                cmd.Parameters.AddWithValue("@isDisponibile", t.isDisponibile);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        controllo = true;
                        

                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine($"Libro non inserito {ex}"); }
                finally { con.Close(); }

            }

            return controllo;
        }

        public bool update(Libro t)
        {
            bool controllo = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Libro SET titolo = @titolo, annoPubblicazione = @annoPubblicazione, isDisponibile = @isDisponibile WHERE libroID = @libroID";
                cmd.Parameters.AddWithValue("@libroID", t.Id);
                cmd.Parameters.AddWithValue("@titolo", t.Titolo);
                cmd.Parameters.AddWithValue("@annoPubblicazione", t.DataPubblicazione);
                cmd.Parameters.AddWithValue("@isDisponibile", t.isDisponibile);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        controllo = true;

                    con.Close();
                }
                catch (Exception) { Console.WriteLine("Libro non modificato"); }
                finally { con.Close(); }

            }

            return controllo;
        }

        public string stampaLista()
        {
            string stringa = "";

            if (libri is null)
                libri = new List<Libro>();

            foreach (Libro libro in libri)
            {
                stringa += libro.ToString() + "\n";
            }

            return stringa;
        }

        public string stampaDisponibili()
        {
            string stringa = "";

            if (libri is null)
                libri = new List<Libro>();

            foreach (Libro libro in libri.Where(l => l.isDisponibile == true))
            {
                stringa += libro.ToString() + "\n";
            }

            return stringa;
        }
    }
}
