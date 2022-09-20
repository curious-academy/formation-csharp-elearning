using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Class qui représente le joueur, la joueuse dans le jeu
    /// </summary>
    public class Player
    {
        #region Fields
        private string email = "";
        // private string pseudo;
        private DateOnly dateDeNaissance;

        private Player[] Amis = new Player[3];
        #endregion

        #region Constructors
        public Player(string pseudo, DateOnly dateNaissance)
        {
            this.Pseudo = pseudo;
            this.dateDeNaissance = dateNaissance;
        }

        public Player(string pseudo)
        {
            this.Pseudo = pseudo;
        }

        public Player(DateOnly dateNaissance)
        {
            this.dateDeNaissance = dateNaissance;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Méthode qui permet de changer la position du joueur
        /// </summary>
        public void SeDeplacer()
        {
            System.Console.WriteLine($"{this.Pseudo} Je me déplace");
        }

        public void Attaquer(Ennemi enemy)
        {
            System.Console.WriteLine("J'attaque l'ennemy {0}", enemy);
        }
        #endregion

        #region Properties
        public DateOnly DateDeNaissance
        {
            get
            {
                return this.dateDeNaissance;
            }
            set
            {
                if (value == DateOnly.MinValue)
                {
                    throw new ArgumentException("dateDeNaissance");
                }

                this.dateDeNaissance = value;
            }
        }

        public string Email { get => email; set => email = value; }

        public string Pseudo { get; set; } = "yoda";

        //public DateOnly GetDateDeNaissance()
        //{
        //    return this.dateDeNaissance;
        //}
        //public void SetDateDeNaissance(DateOnly value)
        //{
        //    this.dateDeNaissance = value;
        //}

        /// <summary>
        /// Points de vie, max à 100 (au début du jeu)
        /// </summary>
        public int PointsDeVie { get; set; }
        #endregion
    }
}
