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
    public abstract class Character
    {
        #region Constructors
        public Character()
        {
            this.Prenom = String.Empty;
        }

        public Character(string prenom)
        {
            this.Prenom= prenom;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Méthode qui permet de changer la position du joueur
        /// </summary>
        public virtual void SeDeplacer()
        {
            System.Console.WriteLine($"{this.Prenom} Je me déplace");
        }

        /// <summary>
        /// Méthode qui permet de changer la position du joueur
        /// </summary>
        public void SeDeplacer(Position newPosition)
        {
            this.SeDeplacer();
            this.CurrentPosition = newPosition;
        }

        public void Attaquer(Character enemy)
        {
            System.Console.WriteLine("J'attaque l'ennemi {0}", enemy);
        }
        #endregion

        #region Properties
        public string Prenom { get; set; } = String.Empty;

        public Position CurrentPosition { get; set; } = new Position() { X = 0, Y = 0 };
        #endregion
    }
}
