using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HarryPotter.Games.Core.Forces
{
    /// <summary>
    /// Force du joueur/de la joueuse
    /// </summary>
    [XmlInclude(typeof(LumineuseForce))]
    [XmlInclude(typeof(NeutreForce))]
    [XmlInclude(typeof(ObscureForce))]
    public abstract class Force
    {
        #region Constructors
        public Force(string libelle)
        {
            Libelle = libelle;
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return string.Format("{0}. {1}", Id, Libelle);
        }
        #endregion

        #region Properties
        public int Id { get; set; }

        public string Libelle { get; set; } = string.Empty;
        #endregion
    }
}
