using DbFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            DBIO db = new DBIO();
            PERSON person = new PERSON
            {
                ID = "DAT",
                FULLNAME = "Peter Par",
                DOB = new DateTime(1990, 4, 5),
                DEPARTMENT = "DPA",
                NOTE = "ABC",
                SALARY = 3434
            };
            //db.Insert(person);

            //db.Update(person);

            IQueryable people = db.GetAll();
            foreach(PERSON i in people)
            {
                Console.WriteLine($"{i.ID}, {i.FULLNAME}, {i.DOB}, {i.DEPARTMENT}, {i.SALARY}, {i.NOTE} ");
            }
            //db.Delete("DAT");
            Console.WriteLine("//////After delete");
            foreach (PERSON i in people)
            {
                Console.WriteLine($"{i.ID}, {i.FULLNAME}, {i.DOB}, {i.DEPARTMENT}, {i.SALARY}, {i.NOTE} ");
            }
            Console.WriteLine("////// salary > 10000");
            IQueryable people2 = db.GetAllWithCondional(x => x.SALARY > 10000);
            foreach (PERSON i in people2)
            {
                Console.WriteLine($"{i.ID}, {i.FULLNAME}, {i.DOB}, {i.DEPARTMENT}, {i.SALARY}, {i.NOTE} ");
            }
            Console.ReadKey();
        }
    }
}
