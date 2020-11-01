using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
    /// Logique d'interaction pour Basket.xaml
    /// </summary>
    public partial class Basket : UserControl
    {
        public Basket()
        {
            InitializeComponent();
            AfficherContenuPanier();

        }

        public void AfficherContenuPanier()
        {                      
            var converter = new BrushConverter();
            
            for (int i=0; i< CreationRecette.Panier.panier.Count; i++)
            {
                StackPanel container = new StackPanel();
                container.Orientation = Orientation.Horizontal;
                container.Background = (Brush)converter.ConvertFromString("#FFFFFF");
                container.Margin = new Thickness(0, 0, 20, 0);
                

                TextBlock element = new TextBlock();
                element.Text = CreationRecette.Panier.panier[i];
                element.Width = 420;
                element.Height = 50;
                element.FontSize = 30;
                element.Margin = new Thickness(10, 0, 0, 0);
                element.VerticalAlignment = VerticalAlignment.Center;               
                element.Foreground = (Brush)converter.ConvertFromString("#000000");
                container.Children.Add(element);


                Button retirerDuPanier = new Button();
                retirerDuPanier.Content = "X";
                retirerDuPanier.Height = 30;
                retirerDuPanier.Background = (Brush)converter.ConvertFromString("#FFFFFF");
                retirerDuPanier.BorderBrush = (Brush)converter.ConvertFromString("#FFFFFF");
                retirerDuPanier.Foreground = (Brush)converter.ConvertFromString("#000000");
                retirerDuPanier.Tag = CreationRecette.Panier.panier[i];
                retirerDuPanier.Click += new RoutedEventHandler(RetirerDuPanier_Click);
                container.Children.Add(retirerDuPanier);

                BasketContent.Children.Add(container);


            }
        }

        public void RetirerDuPanier_Click(object sender, RoutedEventArgs e)
        {
            string recette = (sender as Button).Tag as string;
            CreationRecette.Panier.panier.Remove(recette);
            BasketContent.Children.Clear();
            AfficherContenuPanier();


        }


    }
}
