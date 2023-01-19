using HarryPotter.Games.Core.Interfaces.DataLayers;
using System.Xml.Serialization;

namespace HarryPotter.Games.Core.DataLayers
{
    public class SerializationDataLayer<T> : IDataLayer<T> where T: class
    {
        #region Constructors
        public SerializationDataLayer() { }

        public SerializationDataLayer(string cheminEnregistrement)
        {
            this.CheminEnregistrement = cheminEnregistrement;
        }
        #endregion

        #region Public methods
        public void Ecrire(T item)
        {
            //Type type = typeof(SerializationDataLayer);
            //type.GetMethods();

            XmlSerializer serializer = new XmlSerializer(item.GetType());
            using FileStream? fileStream = new FileStream(this.CheminEnregistrement, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            serializer.Serialize(fileStream, item);
        }

        public T Lire(Type typeObjet)
        {
            XmlSerializer serializer = new XmlSerializer(typeObjet);

            using FileStream? fileStream = new FileStream(this.CheminEnregistrement, FileMode.OpenOrCreate, FileAccess.Read);
            return serializer.Deserialize(fileStream) as T;
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
