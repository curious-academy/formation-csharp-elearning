using HarryPotter.Games.Core.Armes;
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
        #region Constants
        public const int DEFAULT_POINTS_DE_VIE = 100;
        public int Degat = 50;
        public event Action<Character> EstMort;
        #endregion

        #region Fields
        protected readonly AfficherInformation afficher;
        private int pointsDeVie = DEFAULT_POINTS_DE_VIE;
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

            bool pasMemePersonne = this != enemy && this.Prenom != enemy.Prenom;
            if (pasMemePersonne)
            {
                //enemy.PointsDeVie -= this.Degat;
                //if (enemy.PointsDeVie <= 0)
                //{
                //    enemy.PointsDeVie = 0;
                //    enemy.EstMort?.Invoke(enemy);
                //}
                enemy.PointsDeVie -= this.Degat;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Points de vie, max à 100 (au début du jeu)
        /// </summary>
        public int PointsDeVie
        {
            get => this.pointsDeVie;
            set
            {
                this.pointsDeVie = value;
                if (this.pointsDeVie <= 0)
                {
                    this.pointsDeVie = 0;
                    this.EstMort?.Invoke(this);
                }
            }
        }

        public string Prenom { get; set; } = String.Empty;

        public Position CurrentPosition { get; set; } = new Position() { X = 0, Y = 0 };

        public Arme? Arme { get; set; }
        #endregion
    }
}
