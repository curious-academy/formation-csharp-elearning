using HarryPotter.Games.Core.Interfaces;
using HarryPotter.Games.Core.Models;
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
        #region Fields
        protected readonly AfficherInformation afficher;
        #endregion

        #region Constructors
        public Character(AfficherInformation afficher) : this(string.Empty, afficher)
        {
        }

        public Character(string prenom, AfficherInformation afficher)
        {
            this.afficher = afficher;
            this.Prenom = prenom;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Méthode qui permet de changer la position du joueur
        /// </summary>
        public virtual void SeDeplacer()
        {
            this.afficher($"{this.Prenom} Je me déplace");
        }

        /// <summary>
        /// Méthode qui permet de changer la position du joueur
        /// </summary>
        public void SeDeplacer(Position newPosition)
        {
            this.SeDeplacer();
            this.CurrentPosition = newPosition;
        }

        public void SeDeplacer(ICalculateurPosition calculateurPosition)
        {
            this.CurrentPosition = calculateurPosition.Calculer();
        }

        public void Attaquer(Character enemy)
        {
            this.afficher($"J'attaque l'ennemi {enemy}");
        }
        #endregion

        #region Properties
        public string Prenom { get; set; } = String.Empty;

        public Position CurrentPosition { get; set; } = new Position() { X = 0, Y = 0 };
        #endregion
    }
}
