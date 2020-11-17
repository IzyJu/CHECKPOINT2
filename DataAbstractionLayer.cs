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
            command.CommandText = " SELECT EleveId,Prenom,Nom FROM Eleve";
            SqlDataReader reader = command.ExecuteReader();
            List<Eleve> Eleves = new List<Eleve>();
            while (reader.Read())
            {
                Eleve newEleve = new Eleve
                {
                    EleveId = reader.GetInt32(0),
                    Prenom = reader.GetString(1),
                    Nom = reader.GetString(2),
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
