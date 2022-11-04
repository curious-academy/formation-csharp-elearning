using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Force du joueur/de la joueuse
    /// </summary>
    public abstract class Force
    {
        #region Constructors
        public Force(string libelle)
        {
            this.Libelle = libelle;
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return String.Format("{0}. {1}", this.Id, this.Libelle);
        }
        #endregion

        #region Properties
        public int Id { get; set; }

        public string Libelle { get; set; } = string.Empty;
        #endregion
    }
}
