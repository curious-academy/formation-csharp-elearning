using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Interfaces.DataLayers
{
    /// <summary>
    /// Contrat pour lire depuis un fichier ou une bdd
    /// </summary>
    public interface ILireData
    {
        /// <summary>
        /// Crée un object depuis un fichier ou une bdd
        /// </summary>
        /// <param name="typeObjet"></param>
        /// <returns></returns>
        object Lire(Type typeObjet);
    }
}
