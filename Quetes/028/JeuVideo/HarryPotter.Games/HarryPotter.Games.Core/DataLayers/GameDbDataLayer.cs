using HarryPotter.Games.Core.Interfaces.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.DataLayers
{
    internal class GameDbDataLayer : DbDataLayer, IDataLayer<Game>
    {
        #region Fields
        #endregion

        #region Constructors
        public GameDbDataLayer(): base() { }
        #endregion

        #region Public methods
        public void Ecrire(Game item)
        {
            using var connection = new SqlConnection(this.ConnectionString);

            try
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = $"SELECT COUNT(*) From Player where Email='{item.CurrentPlayer.Email}'";
                var nbPlayer = (int)command.ExecuteScalar();

                if (nbPlayer == 0)
                {
                    command.CommandText = $"INSERT INTO dbo.Player (Email, Prenom) VALUES('{item.CurrentPlayer.Email}', '{item.CurrentPlayer.Prenom}')";
                    command.ExecuteNonQuery();
                }

                command.CommandText = $"INSERT INTO dbo.Game (PlayerEmail) VALUES('{item.CurrentPlayer.Email}')";
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public Game Lire(Type typeObjet)
        {
            throw new NotImplementedException();
        }

        public List<Game> LireList()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
