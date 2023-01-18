using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    public class Ennemi : Character
    {
        #region Constructors
        public Ennemi(string prenom): base(prenom, null)
        {

        }

        public Ennemi(string prenom, AfficherInformation afficher) : base(prenom, afficher)
        {
        }
        #endregion

        #region Public methods
        public override void SeDeplacer()
        {
            // base.SeDeplacer();

            //if (this.afficher != null) {
            //this.afficher("")}

            this.afficher?.Invoke($"{this.Prenom} je saute de bond en bond");
            // base.SeDeplacer();
        }
        #endregion

        #region Properties
        #endregion
    }
}
