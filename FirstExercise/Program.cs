using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Oracle.ManagedDataAccess.Client;

namespace FirstExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "DATA SOURCE=149.28.144.14/ORCL;USER ID=CooliedNikkemateDb;PASSWORD=CooliedNikkemateDb;Min Pool Size=5;Decr Pool Size=10;PERSIST SECURITY INFO=True;";
            using (var conn = new OracleConnection(connString))
            {
                string cmdInsert = "INSERT INTO PERSON (ID,FULLNAME) VALUES (:ID, :FULLNAME, :)";
                using (var cmd = new OracleCommand(cmdInsert, conn))
                {
                    conn.Open();
                    string idParam = "10001";
                    string fullNameParam = "Hoang An";
                    cmd.Parameters.Add(":ID", idParam);
                    cmd.Parameters.Add(":ID", fullNameParam);

                    cmd.ExecuteNonQuery();
                    
                }

                //string cmdSelect = "SELECT * FROM PERSON ";
                //using (var cmd = new OracleCommand(cmdSelect, conn))
                //{
                //    var reader = cmd.ExecuteReader();
                //    Console.WriteLine("Data from Table: " + reader);
                //}

                //string cmdDelete = "DELETE FROM PERSON WHERE ID != 100 ";
                //using (var cmd = new OracleCommand(cmdDelete, conn))
                //{
                //    var rowEffect = cmd.ExecuteNonQuery();
                //    Console.WriteLine($"Deleted = {rowEffect} row");
                //}

                //string cmdUpdate = "UPDATE PERSON SET ID = 1 , FULLNAME = 'NONE' WHERE ID = 100";
                //using (var cmd = new OracleCommand(cmdUpdate, conn))
                //{
                //    var rowEffect = cmd.ExecuteNonQuery();
                //    Console.WriteLine($"Updated = {rowEffect} row");
                //}
                //conn.Close();
            }



        }
    }
}
