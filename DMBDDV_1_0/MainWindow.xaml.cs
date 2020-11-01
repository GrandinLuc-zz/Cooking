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
using DMBDDV_1_0.ViewModels;
using MaterialDesignThemes.Wpf;
using DMBDDV_1_0.Views;
using DMBDDV_1_0;

namespace DMBDDV_1_0
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal bool voletOuvert = false;
        public class Logged
        {
            static public bool logged = false;
            static public bool estCreateur = false;
            static public string pseudo;
            static public string password;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AccueilViewModel();
        }

        private void OuvertureVolets_Click(object sender, RoutedEventArgs e)
        {
            OuvrirLeVolet();
        }
        public void OuvrirLeVolet()
        {
            if (voletOuvert == false) // On ouvre le volet
            {
                // Gestion des largeurs du datacontext et du volet
                ContentControler.Width = 800;
                Volet.Width = 200;
                (OuvertureVolets.Content as PackIcon).Kind = PackIconKind.Close;
                voletOuvert = true;

                // Gestion des textes des bouttons
                ChefTextBox.Width = 120;
                BasketTextBox.Width = 120;
                ProfileTextBox.Width = 120;


            }
            else // On ferme le volet
            {
                // Gestion des largeurs du datacontext et du volet
                ContentControler.Width = 930;
                Volet.Width = 70;
                (OuvertureVolets.Content as PackIcon).Kind = PackIconKind.Menu;
                voletOuvert = false;

                // Gestion des textes des bouttons
                ChefTextBox.Width = 0;
                BasketTextBox.Width = 0;
                ProfileTextBox.Width = 0;
            }
        }       
        public void LoginAccess()
        {
            ChefButton.IsEnabled = true;
            ProfileButton.IsEnabled = true;
            BasketButton.IsEnabled = true;
        }
        public void Recette()
        {
            DataContext = new CreationRecetteViewModels();
        }      

        private void ChefButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CreationRecetteViewModels();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BasketViewModel();
            
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProfileViewModel();
        }
        public void Register()
        {
            DataContext = new ProfileViewModel();
        }
        public void RetourLogin()
        {
            DataContext = new AccueilViewModel();
        }

        private void Demo_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DemoViewModel();
        }
        public void AjouterScreen()
        {
            DataContext = new AjouterRecetteViewModel();
        }
    }
}
