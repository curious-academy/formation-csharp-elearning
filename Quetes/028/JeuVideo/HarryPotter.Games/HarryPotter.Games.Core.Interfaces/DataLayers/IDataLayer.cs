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
    public interface IDataLayer<Titem1> : IEcrireData<Titem1>, ILireData<Titem1> where Titem1 : class
    {
        
    }
}
