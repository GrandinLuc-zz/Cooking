using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
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
    /// Logique d'interaction pour Demo.xaml
    /// </summary>
    public partial class Demo : UserControl
    {
        public List<string> listeNoms = new List<string>();
        public Demo()
        {
            InitializeComponent();

            // Charger les créateurs et les recettes

            Requete("SELECT distinct createur from recettes;", "cdr");
            for(int i = 0; i< listeNoms.Count; i++)
            {
                Requete("Select count(*) from recettes where createur ='"+listeNoms[i]+"';", listeNoms[i]);
            }
            Requete("SELECT nomProduit FROM produits WHERE stockActuel <= 2*stockMin;", "produit");
            Requete("SELECT (select count(*) FROM clients) + (select count(*) from createurs);", "nbClients");
            Requete("SELECT count(*) FROM createurs;", "nbCreateurs");
            Requete("SELECT count(*) FROM recettes;", "nbRecettes");
            
            
        }
        public StackPanel ScrollViewerElement(string primero, string secundo = "")
        {
            StackPanel container = new StackPanel();
            container.Orientation = Orientation.Horizontal;
            var converter = new BrushConverter();
            if (secundo != "")
            {
                TextBlock FirstBox = new TextBlock();
                FirstBox.Width = 70;
                FirstBox.Text = primero;
                FirstBox.FontSize = 20;
                FirstBox.TextAlignment = TextAlignment.Center;
                FirstBox.Foreground = (Brush)converter.ConvertFromString("#000000");

                TextBlock SecondBox = new TextBlock();
                SecondBox.Width = 180;
                SecondBox.Text = secundo;
                SecondBox.FontSize = 20;
                SecondBox.TextAlignment = TextAlignment.Center;
                SecondBox.Foreground = (Brush)converter.ConvertFromString("#000000");

                container.Children.Add(FirstBox);
                container.Children.Add(SecondBox);
            }
            else
            {
                TextBlock FirstBox = new TextBlock();
                FirstBox.Width = 250;
                FirstBox.Text = primero;
                FirstBox.FontSize = 15;
                FirstBox.TextAlignment = TextAlignment.Center;
                FirstBox.Foreground = (Brush)converter.ConvertFromString("#000000");

                container.Children.Add(FirstBox);
            }

            return container;
        }
        public void Requete(string requete, string cas)
        {
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
                
                if (cas == "cdr")
                {                   
                    listeNoms.Add(listeValeurs[0]);                   
                }                
                else if(cas == "produit")
                {
                    Ingredients_Container.Children.Add(ScrollViewerElement(listeValeurs[0]));
                }
                else if(cas == "ingredient")
                {
                     Recettes_Container.Children.Add(ScrollViewerElement(listeValeurs[0]));
                }
                else if(cas == "nbClients")
                {
                    Nb_Clients.Text = listeValeurs[0];
                }
                else if (cas == "nbCreateurs")
                {
                    Nb_CdR.Text = listeValeurs[0];
                }
                else if (cas == "nbRecettes")
                {
                    Nb_recettes.Text = listeValeurs[0];
                }
                else
                {
                    CdR_Container.Children.Add(ScrollViewerElement(cas, listeValeurs[0]));
                }


            }

            connection.Close();
        }

        private void Recette_Click(object sender, RoutedEventArgs e)
        {
            Recettes_Container.Children.Clear();
            Requete("SELECT nomRecette FROM recettes WHERE ingredients LIKE '%"+Ingredient_Input.Text+"%';", "ingredient");           
        }
    }
}
