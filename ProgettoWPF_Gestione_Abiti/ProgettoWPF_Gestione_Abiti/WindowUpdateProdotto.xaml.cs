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
    /// Logica di interazione per WindowUpdateProdotto.xaml
    /// </summary>
    public partial class WindowUpdateProdotto : Window
    {
        public WindowUpdateProdotto()
        {
            InitializeComponent();

            cmbCategoria.ItemsSource = CategoriumDAL.getInstance().findAll();

            Prodotto? prodotto = WindowProdotti.selectedProdotto;

            if (prodotto is not null)
            {
                txtNome.Text = prodotto.Nome;
                txtMarca.Text = prodotto.Marca;
                txtDescrizione.Text = prodotto.Descrizione;
            }
        }

        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Modifica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int prodottoId = WindowProdotti.selectedProdotto.ProdottoId + 1;

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
                    ProdottoDAL.getInstance().update(new Prodotto() { ProdottoId = prodottoId, Nome = nome, Marca = marca, CategoriaRif = categoria, Descrizione = descrizione });
                }
            }
            catch { MessageBox.Show("Errore"); }

            Close();
        }
    }
}
