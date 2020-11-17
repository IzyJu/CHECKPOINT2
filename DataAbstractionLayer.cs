using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check_Point2
{
    static class DataAbstractionLayer
    {
        private static SqlConnection _connection = new SqlConnection();
        public static void Connect(SqlConnectionStringBuilder builder)
        {
            _connection.ConnectionString = builder.ConnectionString;
            _connection.Open();
        }
        public static void Disconnect(SqlConnectionStringBuilder builder)
        {
            _connection.Close();
        }
        internal static IEnumerable<Eleve> SelectAllStudent()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT AVG(Controle.Note) AS Moyenne ,Eleve.Nom,Eleve.Prenom FROM Controle JOIN Eleve ON Eleve.EleveId = Controle.FK_EleveId Group by Eleve.Nom,Eleve.Prenom";
            SqlDataReader reader = command.ExecuteReader();
            List<Eleve> Eleves = new List<Eleve>();
            while (reader.Read())
            {
                Eleve newEleve = new Eleve
                {
                    Moyenne = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom =reader.GetString(2)
                };
                Eleves.Add(newEleve);
            }
            reader.Close();
            return Eleves;
        }
        internal static IEnumerable<Eleve> SelectStudentByLastname(String Names)
        {
            SqlCommand command2 = _connection.CreateCommand();
            command2.CommandText = " SELECT Prenom,Nom FROM Eleve Where Nom='"+Names+"'";
            SqlDataReader reader = command2.ExecuteReader();
            List<Eleve> Eleves = new List<Eleve>();
            while (reader.Read())
            {
                Eleve newEleve = new Eleve
                {
                    Prenom = reader.GetString(0),
                    Nom = reader.GetString(1),
                };
                Eleves.Add(newEleve);
            }
            reader.Close();
            return Eleves;
        }
    }
}
