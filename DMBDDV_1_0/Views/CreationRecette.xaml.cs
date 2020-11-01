using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.SqlServer;
using MySql.Data.MySqlClient;

namespace DMBDDV_1_0.Views
{
    /// <summary>
    /// Logique d'interaction pour CreationRecette.xaml
    /// </summary>
    public partial class CreationRecette : UserControl
    {
        bool prixTri = false;
        bool etoilesTri = false;
        bool nomTri = false;
        

        public class Panier
        {
            static public List<string> panier = new List<string>();
        }
        
        public CreationRecette()
        {
            InitializeComponent();
            RequeteEtAffichage("SELECT nomRecette,typePlat,prix,nbretoile,createur FROM recettes;");

        }
        public void AjouterRecette(string imagePlat, int nbEtoiles, string headerText, string descriptionText, int prix, string createur )
        {
            StackPanel main = new StackPanel();
            main.Orientation = Orientation.Horizontal;
            main.Width = 800;
            main.Height = 100;
            main.Margin = new Thickness(0, 10, 0, 10);

            Image plat = new Image();
            plat.Source = new BitmapImage(new Uri(imagePlat));
            plat.Margin = new Thickness(5);

            StackPanel textContainer = new StackPanel();
            textContainer.Orientation = Orientation.Vertical;
            textContainer.Margin = new Thickness(10);

            TextBlock header = new TextBlock();
            header.Text = headerText;
            header.FontSize = 30;
            header.Width = 380;

            
            TextBlock description = new TextBlock();
            description.Text = descriptionText + " Recette postée par: " + createur;
            description.FontSize = 15;
            description.Width = 380;
            description.TextWrapping = TextWrapping.Wrap;

            Button prixCook = new Button();
            prixCook.Content = prix+" cook";
            prixCook.VerticalAlignment = VerticalAlignment.Center;
            prixCook.FontSize = 15;
            prixCook.Margin = new Thickness(30, 0, 0, 0);
            prixCook.Tag = headerText;
            var converter = new BrushConverter();
            prixCook.Background = (Brush)converter.ConvertFromString("#4AD7D1");
            prixCook.Foreground = (Brush)converter.ConvertFromString("#000000");
            prixCook.Click += new RoutedEventHandler(AjouterAuPanier_Click);

            StackPanel etoilesContainer = new StackPanel();
            etoilesContainer.Orientation = Orientation.Horizontal;
            etoilesContainer.Margin = new Thickness(5, 0, 0, 0);


            textContainer.Children.Add(header);


            for(int i = 0; i< nbEtoiles; i++)
            {
                Image etoiles = new Image();
                etoiles.Source = new BitmapImage(new Uri("/Resources/etoile.jpg", UriKind.Relative));
                etoiles.Height = 20;
                etoiles.Width = 20;
                etoiles.HorizontalAlignment = HorizontalAlignment.Left;
                etoilesContainer.Children.Add(etoiles);
            }
            textContainer.Children.Add(etoilesContainer);
            textContainer.Children.Add(description);

            main.Children.Add(plat);
            main.Children.Add(textContainer);
            main.Children.Add(prixCook);
          
            RecipiesContainer.Children.Add(main);


        }

        public void RequeteEtAffichage(string requete)
        {
            RecipiesContainer.Children.Clear();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;UID=root;PASSWORD=azqswxccc;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = requete;

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string valueAsString = reader.GetValue(i).ToString();
                    currentRowAsString += valueAsString + ", ";
                }                
                string[] listeValeurs = currentRowAsString.Split(',');
                string header = listeValeurs[0];
                string description = listeValeurs[1];
                string prix = listeValeurs[2];
                string etoiles = listeValeurs[3];
                string createurRecette = listeValeurs[4];
                AjouterRecette("https://media.gettyimages.com/photos/gourmet-salad-picture-id168855393?s=1024x1024",
                Int32.Parse(etoiles), header, description, Int32.Parse(prix), createurRecette);


            }

            connection.Close();
        }

        private void Prix_Click(object sender, RoutedEventArgs e)
        {
            if (prixTri == false)
            {
                RequeteEtAffichage("SELECT nomRecette,typePlat,prix,nbretoile,createur FROM recettes ORDER BY prix;");
                prixTri = true;
            }
            else
            {
                RequeteEtAffichage("SELECT nomRecette,typePlat,prix,nbretoile,createur FROM recettes ORDER BY prix DESC;");
                prixTri = false;
            }
        }

        private void Nom_Click(object sender, RoutedEventArgs e)
        {
            
            if (nomTri == false)
            {
                RequeteEtAffichage("SELECT nomRecette,typePlat,prix,nbretoile,createur FROM recettes ORDER BY nomRecette;");
                nomTri = true;
            }
            else
            {
                RequeteEtAffichage("SELECT nomRecette,typePlat,prix,nbretoile,createur FROM recettes ORDER BY nomRecette DESC;");
                nomTri = false;
            }
        }

        private void Etoiles_Click(object sender, RoutedEventArgs e)
        {
            if(etoilesTri == false)
            {
                RequeteEtAffichage("SELECT nomRecette,typePlat,prix,nbretoile,createur FROM recettes ORDER BY nbretoile DESC;");
                etoilesTri = true;
            }
            else
            {
                RequeteEtAffichage("SELECT nomRecette,typePlat,prix,nbretoile,createur FROM recettes ORDER BY nbretoile;");
                etoilesTri = false;
            }

            
        }

        public void AjouterAuPanier_Click(object sender, RoutedEventArgs e)
        {
            string recette = (sender as Button).Tag as string; 


            if (Panier.panier.Contains(recette))
            {
                Panier.panier.Remove(recette);
                MessageBox.Show(recette + " retiré du panier !");
            }
            else
            {
                Panier.panier.Add(recette);
                MessageBox.Show(recette + " ajouté au panier !");
            }
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.AjouterScreen();
        }
    }
}
