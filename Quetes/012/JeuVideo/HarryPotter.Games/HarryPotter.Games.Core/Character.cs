using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Classe parente
    /// </summary>
    public class Character
    {
        #region Public methods
        /// <summary>
        /// Méthode qui permet de changer la position du joueur
        /// </summary>
        public virtual void SeDeplacer()
        {
            System.Console.WriteLine($"{this.Prenom} Je me déplace");
        }

        public void Attaquer(Character enemy)
        {
            System.Console.WriteLine("J'attaque l'ennemi {0}", enemy);
        }
        #endregion

        #region Properties
        public string Prenom { get; set; } = String.Empty;
        #endregion
    }
}
