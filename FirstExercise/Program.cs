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
        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            string connString = "DATA SOURCE=149.28.144.14/ORCL;USER ID=CooliedNikkemateDb;PASSWORD=CooliedNikkemateDb;Min Pool Size=5;Decr Pool Size=10;PERSIST SECURITY INFO=True;";

            using (var conn = new OracleConnection(connString))
            {
                //string cmdInsert = "INSERT INTO PERSON (ID,FULLNAME,DOB, SALARY, DEPARTMENT, NOTE) VALUES (:ID, :FULLNAME, :DOB, :SALARY, :DEPARTMENT, :NOTE)";
                conn.Open();
                //using (var cmd = new OracleCommand(cmdInsert, conn))
                //{
                //    string idParam = "10005";
                //    string fullNameParam = "Thien An";
                //    string dobParam = "10/DEC/2000";
                //    string salaryParam = "1333.05";
                //    string departmentParam = "BA";
                //    string noteParam = "Gorgous";

                //    cmd.Parameters.Add(":ID", idParam);
                //    cmd.Parameters.Add(":FULLNAME", fullNameParam);
                //    cmd.Parameters.Add(":DOB", dobParam);
                //    cmd.Parameters.Add(":SALARY", salaryParam);
                //    cmd.Parameters.Add(":DEPARTMENT", departmentParam);
                //    cmd.Parameters.Add(":NOTE", noteParam);

                //    cmd.ExecuteNonQuery();
                //}

                string cmdSelect = "SELECT * FROM PERSON";
                using (var cmd = new OracleCommand(cmdSelect, conn))
                {   
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["ID"].ToString() + "\t" + reader["FULLNAME"].ToString() + "\t" + reader["DOB"].ToString() + "\t" + reader["SALARY"].ToString() + "\t" + reader["DEPARTMENT"].ToString() + "\t" + reader["NOTE"].ToString() + "\t");
                    }

                }



                string cmdUpdate = "UPDATE PERSON SET ID = '11111' , FULLNAME = 'NONE' WHERE ID = '10001'";
                using (var cmd = new OracleCommand(cmdUpdate, conn))
                {
                    var rowEffect = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Updated = {rowEffect} row");
                }


                string cmdDelete = "DELETE FROM PERSON WHERE ID == '100' ";
                using (var cmd = new OracleCommand(cmdDelete, conn))
                {
                    try
                    {
                        var rowEffect = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Deleted = {rowEffect} row");
                    }
                    catch(Exception x)
                    {
                        Console.WriteLine("Exception: " + x.Message);
                    }
                    
                }
                Console.ReadLine();

                conn.Close();

            }
        }
    }
}
