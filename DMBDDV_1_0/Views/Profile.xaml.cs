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

namespace DMBDDV_1_0.Views
{
    /// <summary>
    /// Logique d'interaction pour Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            if(MainWindow.Logged.logged == false)
            {

                Button retourAuLogin = new Button();
                retourAuLogin.Content = "Vous avez déjà un compte ?";
                retourAuLogin.Height = 50;
                retourAuLogin.Width = 300;
                var converter = new BrushConverter();
                retourAuLogin.Background = (Brush)converter.ConvertFromString("#4AD7D1");
                retourAuLogin.Foreground = (Brush)converter.ConvertFromString("#000000");    
                retourAuLogin.Click += new RoutedEventHandler(RetourLogin_Click);
                retourAuLogin.Margin = new Thickness(0,30,0,0);


                MainPanel.Children.Add(retourAuLogin);

                Valider_TextBlock.Text = "S'inscrire";
            }

        }

        public void RetourLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.RetourLogin();
        }

        private void Valider_Button_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.Logged.logged == false)
            {
                // Vérifier si l'utilisateur existe déjà avec une requête, soit créer un nouvel utilisateur dans la base ou mettre un message d'érreur
                MessageBox.Show("Bienvenue sur la plateforme cooking !");
                MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
                parentWindow.Recette();
                parentWindow.LoginAccess();
            }
            else
            {
                // Mettre à jour les données de l'utilisateur
                MessageBox.Show("Vos données ont bien été mises à jour!");
            }
        }
        
        // Méthodes pour les placeholders (teneurs de place est moins parlant)
        private void Nom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Nom.Text == "Nom" && Nom.Foreground == Brushes.Gray)
            {
                Nom.Text = "";
                Nom.Foreground = Brushes.Black;
            }
        }

        private void Nom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Nom.Text == "")
            {
                Nom.Text = "Nom";
                Nom.Foreground = Brushes.Gray;
            }
        }

        private void Prenom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Prenom.Text == "Prénom" && Prenom.Foreground == Brushes.Gray)
            {
                Prenom.Text = "";
                Prenom.Foreground = Brushes.Black;
            }
        }

        private void Prenom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Prenom.Text == "")
            {
                Prenom.Text = "Prénom";
                Prenom.Foreground = Brushes.Gray;
            }
        }

        private void Pseudo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Pseudo.Text == "Pseudo" && Pseudo.Foreground == Brushes.Gray)
            {
                Pseudo.Text = "";
                Pseudo.Foreground = Brushes.Black;
            }
        }

        private void Pseudo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Pseudo.Text == "")
            {
                Pseudo.Text = "Pseudo";
                Pseudo.Foreground = Brushes.Gray;
            }
        }

        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Email.Text == "Email" && Email.Foreground == Brushes.Gray)
            {
                Email.Text = "";
                Email.Foreground = Brushes.Black;
            }
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Text = "Email";
                Email.Foreground = Brushes.Gray;
            }
        }

        private void Num_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Num.Text == "Numéro de téléphone" && Num.Foreground == Brushes.Gray)
            {
                Num.Text = "";
                Num.Foreground = Brushes.Black;
            }
        }

        private void Num_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Num.Text == "")
            {
                Num.Text = "Numéro de téléphone";
                Num.Foreground = Brushes.Gray;
            }
        }

        private void Adresse_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Adresse.Text == "Adresse" && Adresse.Foreground == Brushes.Gray)
            {
                Adresse.Text = "";
                Adresse.Foreground = Brushes.Black;
            }
        }

        private void Adresse_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Adresse.Text == "")
            {
                Adresse.Text = "Adresse";
                Adresse.Foreground = Brushes.Gray;
            }
        }
    }
}
