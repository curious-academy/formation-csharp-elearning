using HarryPotter.Games.Core.Interfaces.DataLayers;
using System.Xml.Serialization;

namespace HarryPotter.Games.Core.DataLayers
{
    public class SerializationDataLayer : IDataLayer
    {
        #region Constructors
        public SerializationDataLayer() { }

        public SerializationDataLayer(string cheminEnregistrement)
        {
            this.CheminEnregistrement = cheminEnregistrement;
        }
        #endregion

        #region Public methods
        public void Ecrire(object item)
        {
            //Type type = typeof(SerializationDataLayer);
            //type.GetMethods();

            XmlSerializer serializer = new XmlSerializer(item.GetType());
            using FileStream? fileStream = new FileStream(this.CheminEnregistrement, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            serializer.Serialize(fileStream, item);
        }

        public object Lire(Type typeObjet)
        {
            XmlSerializer serializer = new XmlSerializer(typeObjet);

            using FileStream? fileStream = new FileStream(this.CheminEnregistrement, FileMode.OpenOrCreate, FileAccess.Read);
            return serializer.Deserialize(fileStream);
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
