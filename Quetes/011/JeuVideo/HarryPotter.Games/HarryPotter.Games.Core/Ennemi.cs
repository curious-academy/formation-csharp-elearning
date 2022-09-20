using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    public class Ennemi
    {
        #region Constants
        public const int DEFAULT_POINTS_DE_VIE = 100;
        #endregion

        #region Constructors
        public Ennemi(string prenom)
        {
            this.Prenom = prenom;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Méthode qui permet de changer la position du joueur
        /// </summary>
        public void SeDeplacer()
        {
            System.Console.WriteLine($"{this.Prenom} Je me déplace");
        }

        public void Attaquer(Player enemy)
        {
            System.Console.WriteLine("J'attaque le player {0}", enemy);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Points de vie, max à 100 (au début du jeu)
        /// </summary>
        public int PointsDeVie { get; set; } = DEFAULT_POINTS_DE_VIE;

        public string Prenom { get; set; } = string.Empty;
        #endregion
    }
}
