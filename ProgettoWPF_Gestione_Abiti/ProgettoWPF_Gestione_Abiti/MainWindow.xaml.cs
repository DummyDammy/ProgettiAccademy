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

<<<<<<< HEAD
        private void ToProdottiWindow(object sender, RoutedEventArgs e)
        {
            WindowProdotti finestra = new WindowProdotti();

            finestra.Show();

            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
=======
        void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        bool isMaximized = false;
        void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (isMaximized)
                {
                    WindowState = WindowState.Normal;
                    Width = 1080;
                    Height = 720;

                    isMaximized = false;
                }

                else
                {
                    WindowState = WindowState.Maximized;
                    isMaximized = false;
                }
            }
>>>>>>> 95dc14e6d2db2a1a357cf2ff1cdf7382bcca283e
        }
    }
}