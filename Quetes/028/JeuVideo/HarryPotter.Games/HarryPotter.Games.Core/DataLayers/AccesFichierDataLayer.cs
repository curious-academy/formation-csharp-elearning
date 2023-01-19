using HarryPotter.Games.Core.Interfaces.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HarryPotter.Games.Core.DataLayers
{
    public class AccesFichierDataLayer<T> : IDataLayer<T> where T : class
    {
        #region Fields
        // private readonly string cheminEnregistrement;
        #endregion

        #region Constructors
        public AccesFichierDataLayer(string cheminEnregistrement)
        {
            this.CheminEnregistrement = cheminEnregistrement;
        }
        #endregion

        #region Public methods
        public void Ecrire(T item)
        {
            if (! File.Exists(this.CheminEnregistrement))
            {
                var streamWriter = File.CreateText(this.CheminEnregistrement);
                // streamWriter.AutoFlush = true;

                streamWriter.WriteLine(item.ToString());

                streamWriter.Close();
            } 
            else
            {
                using FileStream fileStream = File.Open(this.CheminEnregistrement, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                try
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(item.ToString());

                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Flush();
                }
                finally
                {
                    fileStream.Close();
                }
            }

            System.IO.File.WriteAllText(this.CheminEnregistrement, item.ToString());
        }

        public T Lire(Type typeObjet)
        {
            throw new NotImplementedException();
        }

        public List<T> LireList()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        public string CheminEnregistrement
        {
            get;
            init;
        }
        #endregion
    }
}
