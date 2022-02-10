using DbFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBCrud
{
    /// <summary>
    /// Code by Dat
    /// </summary>
    public class DBIO
    {
        OracleDb _context = new OracleDb();
        public IQueryable<PERSON> GetAll()
        {
            return _context.People.AsQueryable();
        }
        public IQueryable<PERSON> GetAllWithCondional(Expression<Func<PERSON,bool>> expression)
        {
            return _context.People.Where(expression).OrderBy(x=> x.FULLNAME).ThenBy(i => i.ID).AsQueryable();
        }
        public PERSON GetById(string id)
        {
            return _context.People.Where(x => x.ID == id).FirstOrDefault();
        }
        public void Insert(PERSON person)
        {
            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
                Console.WriteLine("Add success!");

            }
            catch
            {
                Console.WriteLine("ID was exist!");
            }
        }
        public void Update(PERSON person)
        {
            try
            {
                _context.Entry(person).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void Delete(string id)
        {
            var person = GetById(id);
            if(person == null)
            {
                Console.WriteLine("Can not find person");
            }
            else
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
