using HarryPotter.Games.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Interfaces
{
    /// <summary>
    /// Contrat de calcule de position pour un character du jeu
    /// Vous devez implémenter une classe pour le respecter
    /// </summary>
    public interface ICalculateurPosition
    {
        /// <summary>
        /// Calcule une nouvelle position pour un character donné
        /// </summary>
        /// <returns></returns>
        Position Calculer();
    }
}
