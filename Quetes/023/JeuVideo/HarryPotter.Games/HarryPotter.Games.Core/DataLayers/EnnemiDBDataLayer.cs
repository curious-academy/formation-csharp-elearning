using HarryPotter.Games.Core.Interfaces.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.DataLayers
{
    internal class EnnemiDBDataLayer : IDataLayer<Ennemi>
    {
        #region Fields
        private readonly string connectionString;
        #endregion

        #region Constructors
        public EnnemiDBDataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region Public methods


        public void Ecrire(Ennemi item)
        {
            throw new NotImplementedException();
        }

        public Ennemi Lire(Type typeObjet)
        {
            throw new NotImplementedException();
        }

        public List<Ennemi> LireList()
        {
            List<Ennemi> list = new ();
            using var connection = new SqlConnection(this.connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Prenom FROM Ennemi";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var enemi = new Ennemi(reader["Prenom"].ToString());
                    list.Add(enemi);
                }

                reader.Close();
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return list;
        }


        #endregion
    }
}
