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
    public class Player : Character
    {
        #region Fields
        private string email = "";
        // private string pseudo;
        private DateOnly dateDeNaissance;

        private Player[] Amis = new Player[3];
        #endregion

        #region Constructors
        public Player(string pseudo, DateOnly dateNaissance): base(pseudo)
        {
            this.dateDeNaissance = dateNaissance;
        }

        public Player() : this(string.Empty, DateOnly.MinValue)
        {
            
        }

        public Player(string pseudo): this(pseudo, DateOnly.MinValue)
        {
            this.Prenom = pseudo;
        }

        public Player(DateOnly dateNaissance): this(string.Empty, dateNaissance)
        {
        }
        #endregion

        #region Public methods
        public override void SeDeplacer()
        {
            // base.SeDeplacer();
            Console.WriteLine($"{this.Prenom} Cours Forrest !");
            
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

        public Force ForceSelectionnee { get; set; }
        #endregion
    }
}
