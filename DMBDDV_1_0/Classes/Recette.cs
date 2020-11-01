using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBDDV_1_0.Classes
{
    class Recette
    {
        string urlImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/Pas_d%27image_disponible.svg/1200px-Pas_d%27image_disponible.svg.png";
        int nbEtoiles = 5;
        string header = "PlaceHolder Header";
        string description = "This is a placeholder description that gives more details about this recipe !";
        List<Recette> listeRecettes = new List<Recette>();

        public Recette()
        {
        }

        public Recette(string urlImage, int nbEtoiles, string header, string description)
        {
            this.urlImage = urlImage ?? throw new ArgumentNullException(nameof(urlImage));
            this.nbEtoiles = nbEtoiles;
            this.header = header ?? throw new ArgumentNullException(nameof(header));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
