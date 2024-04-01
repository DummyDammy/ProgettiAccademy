using ProgettoWPF_Gestione_Abiti.Models;
using ProgettoWPF_GestioneAbiti.DAL;
using System.Text;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToProdottiWindow(object sender, RoutedEventArgs e)
        {
            WindowProdotti finestra = new WindowProdotti();

            finestra.Show();

            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}