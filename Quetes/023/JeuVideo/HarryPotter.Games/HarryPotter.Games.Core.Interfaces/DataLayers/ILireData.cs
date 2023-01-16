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
    public interface ILireData<Titem> where Titem : class
    {
        /// <summary>
        /// Crée un object depuis un fichier ou une bdd
        /// </summary>
        /// <param name="typeObjet"></param>
        /// <returns></returns>
        Titem Lire(Type typeObjet);

        /// <summary>
        /// Récupère la liste d'objet depuis un fichier ou une base de données
        /// </summary>
        /// <param name="typeObjet"></param>
        /// <returns></returns>
        List<Titem> LireList();
    }
}
