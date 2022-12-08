using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Interfaces.DataLayers
{
    public interface IEcrireData<Titem> where Titem : class
    {
        /// <summary>
        /// Ecrire dans un fichier / ou bdd
        /// </summary>
        /// <param name="item"></param>
        void Ecrire(Titem item);
    }
}
