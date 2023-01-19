using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Interfaces.DataLayers
{
    /// <summary>
    /// Contrat pour permettre la sauvegarde dans un objet
    /// </summary>
    /// <typeparam name="Titem"></typeparam>
    public interface IEcrireData<Titem> where Titem : class
    {
        /// <summary>
        /// Ecrire dans un fichier / ou bdd
        /// </summary>
        /// <param name="item"></param>
        void Ecrire(Titem item);
    }
}
