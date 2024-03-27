using ProgettoWPF_Gestione_Abiti.Models;
using ProgettoWPF_GestioneAbiti.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgettoWPF_Gestione_Abiti
{
    /// <summary>
    /// Logica di interazione per WindowUtenti.xaml
    /// </summary>
    public partial class WindowUtenti : Page
    {
        public WindowUtenti()
        {
            InitializeComponent();

            dgUtenti.ItemsSource = UtenteDAL.getInstance().findAll();

        }

        private void Salva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = this.txtNome.Text;
                string cognome = this.txtCognome.Text;
                string telefono = this.txtTelefono.Text;

                if (nome.Trim().Equals("") && cognome.Trim().Equals("") && telefono.Trim().Equals(""))
                {
                    MessageBox.Show("Uno dei campi è vuoto!");
                    return;
                }

                UtenteDAL.getInstance().insert(new Utente() { Nome = nome, Cognome = cognome, Telefono = telefono });

                dgUtenti.ItemsSource = UtenteDAL.getInstance().findAll();

                MessageBox.Show("Utente salvato!");
            }
            catch { MessageBox.Show("Errore"); }

            this.txtNome.Text = "";
            this.txtCognome.Text = "";
            this.txtTelefono.Text = "";
        }

        private void Modifica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = this.txtID.Text;
                string nome = this.txtNome2.Text;
                string cognome = this.txtCognome2.Text;
                string telefono = this.txtTelefono2.Text;

                if (nome.Trim().Equals("") && cognome.Trim().Equals("") && telefono.Trim().Equals("") && id.Trim().Equals(""))
                {
                    MessageBox.Show("Uno dei campi è vuoto!");
                    return;
                }

                bool controllo = UtenteDAL.getInstance().update(new Utente() { UtenteId = Convert.ToInt32(id), Nome = nome, Cognome = cognome, Telefono = telefono });

                if (controllo)
                    MessageBox.Show("Utente Modificato");

                else
                    MessageBox.Show("Utente non trovato");
            }
            catch (FormatException) { MessageBox.Show("ID non è un numero"); }
            catch { MessageBox.Show("Errore"); }

            dgUtenti.ItemsSource = UtenteDAL.getInstance().findAll();

            this.txtID.Text = "";
            this.txtNome.Text = "";
            this.txtCognome2.Text = "";
            this.txtTelefono2.Text = "";
        }

        private void Elimina_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = this.txtID2.Text;

                if (id.Trim().Equals(""))
                {
                    MessageBox.Show("Il campo è vuoto!");
                    return;
                }

                bool controllo = UtenteDAL.getInstance().deleteById(Convert.ToInt32(id));

                if (controllo)
                    MessageBox.Show("Utente Eliminato");

                else
                    MessageBox.Show("Utente non trovato");
            }
            catch (FormatException) { MessageBox.Show("ID non è un numero"); }
            catch { MessageBox.Show("Errore"); }

            this.txtID2.Text = "";
        }
    }
}
