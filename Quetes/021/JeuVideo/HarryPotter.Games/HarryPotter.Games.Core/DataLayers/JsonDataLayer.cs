using HarryPotter.Games.Core.Interfaces.DataLayers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.DataLayers
{
    public class JsonDataLayer<T> : IDataLayer<T> where T : class
    {
        #region Fields
        private string cheminEnregistrement;
        #endregion

        #region Constructors
        public JsonDataLayer(string cheminEnregistrement)
        {
            this.cheminEnregistrement = cheminEnregistrement;
        }
        #endregion

        #region Public methods        
        public void Ecrire(T item)
        {
            var json = JsonConvert.SerializeObject(item);
            System.IO.File.WriteAllText(this.cheminEnregistrement, json);
        }

        public T Lire(Type typeObjet)
        {
            var item = JsonConvert.DeserializeObject(cheminEnregistrement);

            return item as T;
        }
        #endregion
    }
}
