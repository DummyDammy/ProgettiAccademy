using ProgettoWPF_Gestione_Abiti.Models;
using ProgettoWPF_GestioneAbiti.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Logica di interazione per WindowProdotti.xaml
    /// </summary>
    public partial class WindowProdotti : Window
    {
        public static Prodotto? selectedProdotto { get; set; } = new Prodotto();
        public WindowProdotti()
        {
            InitializeComponent();

            dgProdotti.ItemsSource = ProdottoDAL.getInstance().findAllGetCategoria();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddProdotto(object sender, RoutedEventArgs e)
        {
            WindowAddProdotto finestra = new WindowAddProdotto();

            finestra.Show();
        }

        private void Home(object sender, RoutedEventArgs e)
        {
            MainWindow finestra = new MainWindow();

            finestra.Show();

            Close();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            dgProdotti.ItemsSource = ProdottoDAL.getInstance().findAllGetCategoria();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            selectedProdotto = dgProdotti.SelectedItem as Prodotto;

            WindowUpdateProdotto finestra = new WindowUpdateProdotto();

            finestra.Show();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Prodotto? prodotto = dgProdotti.SelectedItem as Prodotto;

            if (prodotto != null)
            {
                ProdottoDAL.getInstance().deleteById(prodotto.ProdottoId);
            }

            dgProdotti.ItemsSource = ProdottoDAL.getInstance().findAllGetCategoria();
        }
    }
}
