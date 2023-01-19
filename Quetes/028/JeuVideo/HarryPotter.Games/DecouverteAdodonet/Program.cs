using System.Data;
using System.Data.SqlClient;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

using var connection = new SqlConnection();

connection.ConnectionString = "Server=DESKTOP-1446PBQ;Database=HarryPotter.Udemy.Database;Trusted_Connection=True;";

try
{
    connection.Open();

    using var command = connection.CreateCommand();

    Console.WriteLine("Prenom ?");
    var prenom = Console.ReadLine();

    command.CommandText = $"INSERT INTO [dbo].[Ennemi]  ([Prenom] ,[PointsDeVie]) VALUES ('{prenom}', 110)";
    var nbResultatsMisAJour = command.ExecuteNonQuery();



    command.CommandText = "select Prenom, UPPER(Prenom) as PrenomMaj from Ennemi"; // C'est du sql

    using var reader = command.ExecuteReader();

    //while(reader.Read())
    //{
    //    Console.WriteLine(reader["Prenom"]);
    //    Console.WriteLine(reader["PrenomMaj"]);
    //}

    
    var dataTable = new DataTable();
    dataTable.Load(reader);

    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        DataRow row = dataTable.Rows[i];
    }

    foreach (var row in dataTable.Rows)
    {
        DataRow rowD = row as DataRow;

        Console.WriteLine(rowD["Prenom"]);        
    }
}
catch (Exception ex)
{
    Console.WriteLine("Une erreur est apparue !", ex.Message);
}
finally
{ 
    if(connection.State != System.Data.ConnectionState.Closed)
    {
        connection.Close();
    }
}


