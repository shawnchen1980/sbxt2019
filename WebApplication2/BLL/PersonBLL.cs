using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;
namespace WebApplication2.BLL
{
    public class MyPerson : Person
    {
        public string ChineseName { get; set; }
        public MyPerson(Person p) : base(p)
        {
            this.ChineseName = "hello";
        }
    }
    public class PersonBLL
    {
        public IQueryable<MyPerson> GetPeople()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var records = from x in dc.Person select new MyPerson(x);
            return records;
        }
    }
}