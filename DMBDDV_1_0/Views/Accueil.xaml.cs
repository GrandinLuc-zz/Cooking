using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DMBDDV_1_0;
using DMBDDV_1_0.ViewModels;

namespace DMBDDV_1_0.Views
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : UserControl
    {
        string pseudo = "";
        string password = "";       
        public Accueil()
        {
            InitializeComponent();

        }

        private void Pseudo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ButtonPseudo.Text == "Pseudo" && ButtonPseudo.Foreground == Brushes.Gray)
            {
                ButtonPseudo.Text = "";
                ButtonPseudo.Foreground = Brushes.Black;
            }
        }

        private void Pseudo_LostFocus(object sender, RoutedEventArgs e)
        {
            if(ButtonPseudo.Text == "")
            {
                ButtonPseudo.Text = "Pseudo";
                ButtonPseudo.Foreground = Brushes.Gray;
            }
        }     

        private void ButtonPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if(ButtonPassword.Password == "")
            {
                Placeholder.Width = 300;
                ButtonPassword.Width = 0;
            }
        }

        private void Placeholder_GotFocus(object sender, RoutedEventArgs e)
        {
            Placeholder.Width = 0;
            ButtonPassword.Width = 300;
            ButtonPassword.Focus();
        }

        public void Login_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.LoginAccess();
            parentWindow.Recette();
            MainWindow.Logged.logged = true;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.Register();

        }
    }
}
