using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Configurations
{
    /// <summary>
    /// Configuration complète du jeu
    /// </summary>
    public class GameConfig
    {
        #region Constructors
        public GameConfig(int nbLignes, int nbColonnes)
        {
            this.NbLignes = nbLignes;
            this.NbColonnes = nbColonnes;
        }
        #endregion

        #region Properties
        public int NbLignes { get; set; }
        public int NbColonnes { get; set; }
        #endregion
    }
}
