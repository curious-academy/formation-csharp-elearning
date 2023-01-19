using HarryPotter.Games.Core.Interfaces;
using HarryPotter.Games.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.UI.Console
{
    public class StaticCalculateurPosition : ICalculateurPosition
    {
        #region Fields
        private int x;
        private int y;
        #endregion

        #region Constructors
        public StaticCalculateurPosition(int x, int y)
        {
            this.y = y;
            this.x = x;
        }
        #endregion

        #region Public methods
        public Position Calculer()
        {
            return new Position()
            {
                X = this.x,
                Y = this.y
            };
        }
        #endregion
    }
}
