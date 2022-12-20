using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Menu.Commands
{
    /// <summary>
    /// Contrat pour execute une commande du menu (aka un choix dans le menu)
    /// </summary>
    public interface IMenuCommand
    {
        /// <summary>
        /// Je veux exécuter une commande
        /// </summary>
        void Executer();

        /// <summary>
        /// Index correspondant au choix du menu
        /// </summary>
        int Index { get; }
    }
}
