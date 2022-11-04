using HarryPotter.Games.Core.Interfaces;
using HarryPotter.Games.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    public class RandomCalculateurPosition : ICalculateurPosition
    {
        #region Public methods
        public Position Calculer()
        {
            Random rand = new Random();

            return new Position()
            {
                X = rand.Next(0, 100),
                Y = rand.Next(0, 100)
            };
        }
        #endregion
    }
}
