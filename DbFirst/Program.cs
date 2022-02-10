using DbFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (var db = new OracleDb())
            {
                //select 
                var select = from d in db.People select d;
                Console.WriteLine("ID\tFULNAME\tDOB\tSALARY\tDEPARTMENT\tNOTE");
                foreach(var data in select)
                {
                    Console.WriteLine($"{data.ID}\t{data.FULLNAME}\t{data.DOB}\t{data.SALARY}\t{data.DEPARTMENT}\t{data.NOTE}");
                }

                //insert 
                try
                {
                    var newPerson = new PERSON()
                    { ID = "20001", FULLNAME = "Hoang Minh", DOB = DateTime.Now, SALARY = 12233, DEPARTMENT = "HR", NOTE = "Beautiful" };
                    db.People.Add(newPerson);
                    db.SaveChanges();
                    Console.WriteLine("Add success!");

                }
                catch
                {
                    Console.WriteLine("ID was exist!");
                }

                //update 

                //try
                //{
                //    var dataPerson = db.People.Where(x => x.ID == "10003").FirstOrDefault();
                //    if (dataPerson != null)
                //    {
                //        dataPerson.FULLNAME = "new Hinh";
                //        dataPerson.DOB = DateTime.Now;
                //        dataPerson.SALARY = 111112;
                //        dataPerson.DEPARTMENT = "new BAN";
                //        dataPerson.NOTE = "new NOTE1";
                //        db.SaveChanges();
                //        Console.WriteLine("Update success!");
                //    }
                //}
                //catch
                //{
                //    Console.WriteLine("Exception occur!");
                //}


                //Delete
                //try
                //{
                //    var dataPerson = db.People.Where(x => x.ID == "10003").FirstOrDefault();
                //    if (dataPerson != null)
                //    {
                //        db.People.Remove(dataPerson);
                //        db.SaveChanges();
                //        Console.WriteLine("Delete success!");
                //    }
                //}
                //catch
                //{
                //    Console.WriteLine("Exception occur!");
                //}

                Console.ReadLine();
            }
        }
    }
}
