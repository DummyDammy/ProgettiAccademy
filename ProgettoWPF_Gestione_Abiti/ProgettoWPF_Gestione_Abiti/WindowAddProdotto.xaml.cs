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
using System.Windows.Shapes;

namespace ProgettoWPF_Gestione_Abiti
{
    /// <summary>
    /// Logica di interazione per WindowAddProdotto.xaml
    /// </summary>
    public partial class WindowAddProdotto : Window
    {
        public WindowAddProdotto()
        {
            InitializeComponent();

            cmbCategoria.ItemsSource = CategoriumDAL.getInstance().findAll();
        }

        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Salva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string marca = txtMarca.Text;
                int categoria = cmbCategoria.SelectedIndex + 1;
                string descrizione = txtDescrizione.Text;

                if (nome.Trim().Equals("") || marca.Trim().Equals("") || categoria == 0)
                {
                    MessageBox.Show("Assicurarsi che i campi Nome, Marca e Categoria siano riempiti");
                    return;
                }

                else
                {
                    Prodotto prodotto = new Prodotto();
                    ProdottoDAL.getInstance().insert(new Prodotto() { Nome = nome, Marca = marca, CategoriaRif = categoria, Descrizione = descrizione });
                }
            }
            catch { MessageBox.Show("Errore"); }

            Close();
        }
    }
}
