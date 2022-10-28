using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Interfaces.DataLayers
{
    /// <summary>
    /// Contract d'accès à une base de données
    /// </summary>
    public interface IDataLayer : IEcrireData, ILireData
    {
        
    }
}
