using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Check_Point2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.InitialCatalog = "CheckPoint2";
            stringBuilder.DataSource = @"LOCALHOST\SQLEXPRESS";
            stringBuilder.IntegratedSecurity = true;
            DataAbstractionLayer.Connect(stringBuilder);

            IEnumerable<Eleve> Eleves = DataAbstractionLayer.SelectAllStudent();
            foreach(Eleve eleve in Eleves)
            {
                Console.WriteLine("Nom : {0}    Prenom : {1}    Moyenne : {2}",eleve.Nom,eleve.Prenom,eleve.Moyenne);
            }

            IEnumerable<Eleve> Eleves2 = DataAbstractionLayer.SelectStudentByLastname("AA");
            foreach (Eleve eleve in Eleves2)
            {
                Console.WriteLine("Nom : {0}   Prenom : {1}", eleve.Nom, eleve.Prenom);
            }
        }
    }
}
